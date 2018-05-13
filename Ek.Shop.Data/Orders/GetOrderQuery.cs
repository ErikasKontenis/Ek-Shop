using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Orders
{
    public class GetOrderQuery : RemoteQuery<GetOrderCommand, Order>
    {
        public GetOrderQuery(EkShopContext dbContext)
            : base (dbContext)
        { }

        public override bool IsCacheRequired => false;

        public override async Task<Order> Query(GetOrderCommand command)
        {
            var query = DbContext.Orders
                .Include(o => o.ShippingMethod)
                .Include(o => o.Basket).ThenInclude(o => o.BasketItems).ThenInclude(o => o.Product).ThenInclude(o => o.Route)
                .Include(o => o.Basket).ThenInclude(o => o.BasketItems).ThenInclude(o => o.Product).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Basket).ThenInclude(o => o.BasketItems).ThenInclude(o => o.Product).ThenInclude(o => o.Characteristics)
                .Include(o => o.OrderStatus)
                .AsQueryable();

            if (command.OrderId.HasValue)
                query = query.Where(o => o.Id == command.OrderId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
