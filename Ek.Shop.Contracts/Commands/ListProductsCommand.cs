using Ek.Shop.Contracts.Abstractions;

namespace Ek.Shop.Contracts.Commands
{
    public class ListProductsCommand : PagingCommand
    {
        public ListProductsCommand()
        { }

        public ListProductsCommand(int languageId, int pageIndex = 0, int pageSize = 0, string search = null, string sorting = null)
            : base(pageIndex, pageSize, search, sorting)
        {
            LanguageId = languageId;
        }

        public int LanguageId { get; set; }
    }
}
