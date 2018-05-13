using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Application.Abstractions
{
    public class PageDto<TSource>
    {
        public PageDto(IEnumerable<TSource> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            Items = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public List<TSource> Items { get; set; }

        public int PageIndex { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public int TotalPages { get; }
    }
}
