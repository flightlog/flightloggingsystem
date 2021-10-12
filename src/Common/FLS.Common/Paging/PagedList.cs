using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Common.Paging
{
    public class PagedList<T>
    {
        public PagedList(List<T> items, int page, int pageSize, int totalRows)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalRows = totalRows;
        }

        public List<T> Items { get; }

        public int Page { get; }

        public int PageSize { get; }

        public int TotalRows { get; }
    }
}

