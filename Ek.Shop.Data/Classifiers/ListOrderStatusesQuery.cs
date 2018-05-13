using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Classifiers
{
    public class ListOrderStatusesQuery : RemoteQuery<ListOrderStatusesCommand, List<OrderStatus>>
    {
        public ListOrderStatusesQuery(EkShopContext dbContext)
            : base(dbContext)
        { }

        public override async Task<List<OrderStatus>> Query(ListOrderStatusesCommand command)
        {
            var query = DbContext.OrderStatuses;

            return await query.ToListAsync();
        }
    }
}
