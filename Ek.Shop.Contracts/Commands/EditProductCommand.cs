namespace Ek.Shop.Contracts.Commands
{
    public class EditProductCommand : ICommand
    {
        public EditProductCommand()
        { }

        public EditProductCommand(int productId, int languageId)
        {
            ProductId = productId;
            LanguageId = languageId;
        }

        public int LanguageId { get; set; }

        public int ProductId { get; set; }
    }
}
