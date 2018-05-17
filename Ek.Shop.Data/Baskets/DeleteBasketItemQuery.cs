using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Baskets
{
    public class DeleteBasketItemQuery : RemoteQuery<DeleteBasketItemCommand, BasketItem>
    {
        private readonly IRemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket> _createOrGetUnconfirmedBasketQuery;

        public DeleteBasketItemQuery(EkShopContext dbContext,
            IRemoteQuery<CreateOrGetUnconfirmedBasketCommand, Basket> createOrGetUnconfirmedBasketQuery)
            : base (dbContext)
        {
            _createOrGetUnconfirmedBasketQuery = createOrGetUnconfirmedBasketQuery;
        }

        public override async Task<BasketItem> Query(DeleteBasketItemCommand command)
        {
            var basket = await _createOrGetUnconfirmedBasketQuery.Query(new CreateOrGetUnconfirmedBasketCommand());
            if (basket == null)
            {
                return null;
            }

            var basketItem = basket.BasketItems.FirstOrDefault(o => o.Id == command.BasketItemId);
            if (basketItem != null)
            {
                DbContext.ActionByEntityState(basketItem, EntityState.Deleted);
                await DbContext.SaveChangesAsync();
            }

            return basketItem;
        }
    }
}
