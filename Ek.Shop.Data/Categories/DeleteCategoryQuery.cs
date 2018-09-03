using Ek.Shop.Base.Data.Caches;
using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Routes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Categories
{
    public class DeleteCategoryQuery : RemoteQuery<DeleteCategoryCommand, Category>
    {
        private readonly IRemoteQuery<ListRoutesCommand, List<Route>> _listRoutesQuery;
        private readonly ICache _cache; 

        public DeleteCategoryQuery(EkShopContext dbContext,
            IRemoteQuery<ListRoutesCommand, List<Route>> listRoutesQuery,
            ICache cache)
            : base(dbContext)
        {
            _listRoutesQuery = listRoutesQuery;
            _cache = cache;
        }

        public override async Task<Category> Query(DeleteCategoryCommand command)
        {
            var category = await DbContext.Categories.Include(o => o.Route).FirstOrDefaultAsync(o => o.Id == command.CategoryId);
            if (category == null)
            {
                return null;
            }

            DbContext.ActionByEntityState(category.Route, EntityState.Deleted);
            await DbContext.SaveChangesAsync();

            var routes = await _listRoutesQuery.Query(new ListRoutesCommand());
            foreach (var route in routes.Where(o => o.Category == null && o.Product == null))
            {
                DbContext.ActionByEntityState(route, EntityState.Deleted);
            }
            await DbContext.SaveChangesAsync();

            _cache.ClearRegion(CacheRegions.Category);
            _cache.ClearRegion(CacheRegions.Product);

            return category;
        }
    }
}
