using Ek.Shop.Contracts.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Core.Models
{
    public class PagedList<T>
    {
        public PagedList()
        {
            Items = new List<T>();
        }

        public PagedList(IEnumerable<T> source)
        {
            Items = source;
            TotalCount = Items.Count();
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            if (TotalCount > 0 && pageSize > 0)
            {
                TotalPages = TotalCount / pageSize;

                if (TotalCount % pageSize > 0)
                    TotalPages++;
            }

            PageSize = pageSize;
            PageIndex = pageIndex;

            Items = source;
        }

        public IEnumerable<T> Items { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public bool IsNullOrEmpty()
        {
            return Items == null || Items.IsNullOrEmpty();
        }
    }
}
