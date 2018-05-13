using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Characteristics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Classifiers
{
    public class ListCharacteristicsQuery : RemoteQuery<ListCharacteristicsCommand, List<Characteristic>>
    {
        public ListCharacteristicsQuery(EkShopContext dbContext)
            : base(dbContext)
        { }

        public override async Task<List<Characteristic>> Query(ListCharacteristicsCommand command)
        {
            var query = DbContext.Characteristics;

            return await query.ToListAsync();
        }

    }
}
