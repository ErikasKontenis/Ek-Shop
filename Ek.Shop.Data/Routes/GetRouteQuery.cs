using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Routes;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Routes
{
    public class GetRouteQuery : RemoteQuery<GetRouteCommand, Route>
    {
        public GetRouteQuery(EkShopContext dbContext)
            : base (dbContext)
        { }

        public override bool IsCacheRequired => false;

        public override async Task<Route> Query(GetRouteCommand command)
        {
            var query = DbContext.Routes
                    .Include(o => o.AngularComponent)
                    .Include(o => o.Category)
                    .Include(o => o.InputForm)
                    .Include(o => o.Product);

            if (command.RouteId.HasValue)
            {
                return await query.FirstOrDefaultAsync(o => o.Id == command.RouteId);
            }
            else if (command.Url != null)
            {
                return await query.FirstOrDefaultAsync(o => o.Url == command.Url);
            }
            else
            {
                return await query.FirstOrDefaultAsync();
            }
        }
    }
}
