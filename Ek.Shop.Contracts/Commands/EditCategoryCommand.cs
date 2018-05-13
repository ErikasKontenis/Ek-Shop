namespace Ek.Shop.Contracts.Commands
{
    public class EditCategoryCommand : ICommand
    {
        public EditCategoryCommand()
        { }

        public EditCategoryCommand(int categoryId, int languageId)
        {
            CategoryId = categoryId;
            LanguageId = languageId;
        }

        public int CategoryId { get; set; }

        public int LanguageId { get; set; }
    }
}
