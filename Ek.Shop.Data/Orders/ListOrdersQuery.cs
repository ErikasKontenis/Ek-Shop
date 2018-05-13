using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Orders
{
    public class ListOrdersQuery : RemoteQuery<ListOrdersCommand, PagedList<Order>>
    {
        public ListOrdersQuery(EkShopContext dbContext)
            : base (dbContext)
        { }

        public override bool IsCacheRequired => false;

        public override async Task<PagedList<Order>> Query(ListOrdersCommand command)
        {
            var query = DbContext.Orders
                .Include(o => o.ShippingMethod)
                .Include(o => o.Basket).ThenInclude(o => o.BasketItems).ThenInclude(o => o.Product).ThenInclude(o => o.Route)
                .Include(o => o.Basket).ThenInclude(o => o.BasketItems).ThenInclude(o => o.Product).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Basket).ThenInclude(o => o.BasketItems).ThenInclude(o => o.Product).ThenInclude(o => o.Characteristics)
                .Include(o => o.OrderStatus)
                .AsQueryable();

            if (command.UserId.HasValue)
                query = query.Where(o => o.UserId == command.UserId);

            if (command.Id.HasValue)
                query = query.Where(o => o.Id == command.Id);

            if (!string.IsNullOrEmpty(command.BillingEmail) && command.BillingEmail != "null")
                query = query.Where(o => o.Email == command.BillingEmail);

            if (!string.IsNullOrEmpty(command.BillingLastName) && command.BillingLastName != "null")
                query = query.Where(o => o.LastName == command.BillingLastName);

            if (!string.IsNullOrEmpty(command.BillingName) && command.BillingName != "null")
                query = query.Where(o => o.Name == command.BillingName);

            return await query.OrderByDescending(o => o.Id).ToPagedListAsync(command);
        }
    }
}
