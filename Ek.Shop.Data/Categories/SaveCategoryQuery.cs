using Ek.Shop.Base.Data.Caches;
using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Categories;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Categories
{
    public class SaveCategoryQuery : RemoteQuery<SaveCategoryQueryCommand, Category>
    {
        private readonly ICache _cache;

        public SaveCategoryQuery(EkShopContext dbContext,
            ICache cache)
            : base(dbContext)
        {
            _cache = cache;
        }

        public override bool IsCacheRequired => false;

        public override async Task<Category> Query(SaveCategoryQueryCommand command)
        {
            DbContext.AddOrUpdate(command.Category);
            await DbContext.SaveChangesAsync();

            _cache.ClearRegion(CacheRegions.Category);
            _cache.ClearRegion(CacheRegions.Product);

            return command.Category;
        }
    }
}
