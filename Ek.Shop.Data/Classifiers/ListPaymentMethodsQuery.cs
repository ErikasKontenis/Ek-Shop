using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Classifiers
{
    public class ListPaymentMethodsQuery : RemoteQuery<ListPaymentMethodsCommand, List<PaymentMethod>>
    {
        public ListPaymentMethodsQuery(EkShopContext dbContext)
            : base(dbContext)
        { }

        public override async Task<List<PaymentMethod>> Query(ListPaymentMethodsCommand command)
        {
            var query = DbContext.PaymentMethods.Include(o => o.PaymentMethodTypes);

            return await query.ToListAsync();
        }
    }
}
