using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.AngularComponents;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Classifiers
{
    public class ListAngularComponentsQuery : RemoteQuery<ListAngularComponentsCommand, List<AngularComponent>>
    {
        public ListAngularComponentsQuery(EkShopContext dbContext)
            : base(dbContext)
        { }

        public override async Task<List<AngularComponent>> Query(ListAngularComponentsCommand command)
        {
            var query = DbContext.AngularComponents;

            return await query.ToListAsync();
        }
    }
}
