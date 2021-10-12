using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Common.Paging
{
    /// <summary>
    /// Source code is derived from https://github.com/CypressNorth/.NET-CNPagedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedQuery<T>
    {
        private const int MaxTotalRowsServersideAllowed = 100;

        private readonly IQueryable<T> _items;
        private readonly int? _page;
        private readonly int? _pageSize;

        public PagedQuery(IQueryable<T> items, int? page = null, int? pageSize = null)
        {
            if (page.HasValue && page.Value <= 0) page = 1;
            _items = items;
            _page = page;
            _pageSize = pageSize;
        }

        /// <summary>
        /// The paginated result items
        /// </summary>
        public IQueryable<T> Items
        {
            get
            {
                if (_items == null) return null;
                return _items.Skip((Page - 1) * PageSize).Take(PageSize);
            }
        }

        /// <summary>
        ///  The current start page (row number).
        /// </summary>
        public int Page
        {
            get
            {
                if (_page.HasValue) return _page.Value;

                return 1;
            }
        }

        /// <summary>
        /// The size of the page (returned number of rows).
        /// </summary>
        public int PageSize
        {
            get
            {
                if (_pageSize.HasValue)
                {
                    if (_pageSize.Value > MaxTotalRowsServersideAllowed) return MaxTotalRowsServersideAllowed;

                    return _pageSize.Value;
                }

                return MaxTotalRowsServersideAllowed;
            }
        }

        /// <summary>
        /// The total number of items in the original list of items.
        /// </summary>
        public int TotalRows
        {
            get
            {
                if (_items == null) return 0;

                return _items.Count();
            }
        }
    }
}
