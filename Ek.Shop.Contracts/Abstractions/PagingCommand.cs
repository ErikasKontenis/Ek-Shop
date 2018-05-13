using Ek.Shop.Contracts.Commands;

namespace Ek.Shop.Contracts.Abstractions
{
    public abstract class PagingCommand : ICommand
    {
        public PagingCommand()
        { }

        public PagingCommand(int pageIndex, int pageSize, string search, string sorting)
        {
            if (pageIndex > 0)
                PageIndex = pageIndex;

            PageSize = pageSize;
            Search = search;
            Sorting = sorting;
        }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; }

        public string Search { get; set; }

        public string Sorting { get; set; }
    }
}
