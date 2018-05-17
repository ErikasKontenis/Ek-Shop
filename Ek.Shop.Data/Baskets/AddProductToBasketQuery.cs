using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Baskets;
using Ek.Shop.Domain.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Baskets
{
    public class AddProductToBasketQuery : RemoteQuery<AddProductToBasketCommand, Basket>
    {
        private readonly IRemoteQuery<GetProductCommand, Product> _getProductQuery;
        private readonly IRemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket> _createOrGetUnconfirmedBasketQuery;
        private readonly IWorkContext _workContext;

        public AddProductToBasketQuery(EkShopContext dbContext,
            IRemoteQuery<GetProductCommand, Product> getProductQuery,
            IRemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket> createOrGetUnconfirmedBasketQuery,
            IWorkContext workContext)
            : base (dbContext)
        {
            _getProductQuery = getProductQuery;
            _createOrGetUnconfirmedBasketQuery = createOrGetUnconfirmedBasketQuery;
            _workContext = workContext;
        }

        public override async Task<Basket> Query(AddProductToBasketCommand command)
        {
            var product = await _getProductQuery.Query(new GetProductCommand(command.ProductId, _workContext.WorkingLanguageId));
            if (product == null)
            {
                return null;
            }

            var basket = await _createOrGetUnconfirmedBasketQuery.Query(new CreateOrGetUnconfirmedBasketCommand());
            if (basket == null)
            {
                return null;
            }

            var basketItem = basket.BasketItems.FirstOrDefault(o => o.ProductId == command.ProductId && o.ProductDetailId == command.ProductDetailId);
            if (basketItem == null)
            {
                basketItem = new BasketItem();
                basketItem.BasketId = basket.Id;
                basketItem.ProductDetailId = command.ProductDetailId;
                basketItem.ProductId = product.Id;
                basketItem.Price = product.GetTotalPrice();
                basketItem.Quantity = command.Quantity;
            }
            else
            {
                basketItem.Quantity += command.Quantity;
            }


            DbContext.AddOrUpdate(basketItem);
            await DbContext.SaveChangesAsync();

            return basket;
        }
    }
}
