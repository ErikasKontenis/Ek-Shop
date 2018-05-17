using Ek.Shop.Contracts.Abstractions;
using Ek.Shop.Core.Enums;

namespace Ek.Shop.Contracts.Commands
{
    public class GetProductCommand : CachingCommand
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

        public override string Region => CacheRegions.Product;
    }
}
