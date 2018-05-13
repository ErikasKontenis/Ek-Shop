namespace Ek.Shop.Contracts.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public DeleteProductCommand()
        { }

        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
    }
}
