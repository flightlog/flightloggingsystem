using System.Collections.Generic;
using Newtonsoft.Json;

namespace FLS.Common.Paging
{
    public class PageableSearchFilter<T>
    {
        public PageableSearchFilter()
        {
            Sorting = new Dictionary<string, string>();
        }
        public Dictionary<string, string> Sorting { get; set; }

        public T SearchFilter { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
