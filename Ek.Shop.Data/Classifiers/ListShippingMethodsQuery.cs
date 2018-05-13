using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Classifiers
{
    public class ListShippingMethodsQuery : RemoteQuery<ListShippingMethodsCommand, List<ShippingMethod>>
    {
        public ListShippingMethodsQuery(EkShopContext dbContext)
            : base(dbContext)
        { }

        public override async Task<List<ShippingMethod>> Query(ListShippingMethodsCommand command)
        {
            var query = DbContext.ShippingMethods;

            return await query.ToListAsync();
        }
    }
}
