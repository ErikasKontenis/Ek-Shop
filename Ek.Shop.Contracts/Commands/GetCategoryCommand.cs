namespace Ek.Shop.Contracts.Commands
{
    public class GetCategoryCommand : ICommand
    {
        public GetCategoryCommand()
        { }

        public GetCategoryCommand(int categoryId, int languageId, bool isDisabledIncluded = false)
        {
            CategoryId = categoryId;
            LanguageId = languageId;
            IsDisabledIncluded = isDisabledIncluded;
        }

        public int CategoryId { get; set; }

        public bool IsDisabledIncluded { get; set; }

        public int LanguageId { get; set; }
    }
}
