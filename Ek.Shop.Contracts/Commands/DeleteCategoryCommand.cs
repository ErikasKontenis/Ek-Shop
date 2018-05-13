namespace Ek.Shop.Contracts.Commands
{
    public class DeleteCategoryCommand : ICommand
    {
        public DeleteCategoryCommand()
        { }

        public DeleteCategoryCommand(int categoryId)
        {
            CategoryId = categoryId;
        }

        public int CategoryId { get; set; }
    }
}
