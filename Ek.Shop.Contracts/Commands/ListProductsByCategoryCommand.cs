using Ek.Shop.Contracts.Abstractions;

namespace Ek.Shop.Contracts.Commands
{
    public class ListProductsByCategoryCommand : PagingCommand
    {
        public ListProductsByCategoryCommand()
            : base()
        { }

        public ListProductsByCategoryCommand(int? categoryId, int languageId, bool isShowHomePage = false, int pageIndex = 0, int pageSize = 0, string search = null, string sorting = null)
            : base(pageIndex, pageSize, search, sorting)
        {
            CategoryId = categoryId;
            LanguageId = languageId;
            IsShowHomePage = isShowHomePage;
        }

        public int? CategoryId { get; set; }

        public bool IsShowHomePage { get; set; }

        public int LanguageId { get; set; }
    }
}
