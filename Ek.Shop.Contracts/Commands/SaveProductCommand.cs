using Ek.Shop.Application.Products;
using Ek.Shop.Domain.Products;

namespace Ek.Shop.Contracts.Commands
{
    public class SaveProductCommand : ICommand
    {
        public SaveProductCommand()
        { }

        public SaveProductCommand(SaveProductDto saveProduct, int languageId)
        {
            SaveProduct = saveProduct;
            LanguageId = languageId;
        }

        public int LanguageId { get; set; } 

        public SaveProductDto SaveProduct { get; set; }
    }

    public class SaveProductQueryCommand : ICommand
    {
        public SaveProductQueryCommand()
        { }

        public SaveProductQueryCommand(Product saveProduct)
        {
            Product = saveProduct;
        }

        public Product Product { get; set; }
    }
}
