using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Routes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Routes
{
    public class ListRoutesQuery : RemoteQuery<ListRoutesCommand, List<Route>>
    {
        public ListRoutesQuery(EkShopContext dbContext)
            : base (dbContext)
        { }

        public override async Task<List<Route>> Query(ListRoutesCommand command)
        {
            var query = DbContext.Routes
                    .Include(o => o.AngularComponent)
                    .Include(o => o.Category)
                    .Include(o => o.InputForm)
                    .Include(o => o.Product);

            if (command.RouteId.HasValue)
            {
                return await query.Where(o => o.Id == command.RouteId).ToListAsync();
            }
            else if (command.Url != null)
            {
                return await query.Where(o => o.Url == command.Url).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }

        }
    }
}
