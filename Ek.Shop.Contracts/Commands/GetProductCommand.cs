namespace Ek.Shop.Contracts.Commands
{
    public class GetProductCommand : ICommand
    {
        public GetProductCommand()
        { }

        public GetProductCommand(int productId, int languageId)
        {
            ProductId = productId;
            LanguageId = languageId;
        }

        public int LanguageId { get; set; }

        public int ProductId { get; set; }
    }
}
