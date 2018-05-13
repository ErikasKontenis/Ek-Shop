using Ek.Shop.Contracts.Abstractions;

namespace Ek.Shop.Contracts.Commands
{
    public class ListCategoriesCommand : PagingCommand
    {
        public ListCategoriesCommand()
        { }

        public ListCategoriesCommand(int inputFormId, int languageId, bool isDefaultCategoriesIncluded = false, bool isDisabledIncluded = false, int pageIndex = 0, int pageSize = 0, string search = null, string sorting = null)
            : base(pageIndex, pageSize, search, sorting)
        {
            InputFormId = inputFormId;
            LanguageId = languageId;
            IsDefaultCategoriesIncluded = isDefaultCategoriesIncluded;
            IsDisabledIncluded = isDisabledIncluded;
        }

        public int InputFormId { get; set; }

        public bool IsDefaultCategoriesIncluded { get; set; }

        public bool IsDisabledIncluded { get; set; }

        public int LanguageId { get; set; }
    }
}
