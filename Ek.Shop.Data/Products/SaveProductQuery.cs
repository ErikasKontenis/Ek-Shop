using Ek.Shop.Base.Data.Caches;
using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Products;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Products
{
    public class SaveProductQuery : RemoteQuery<SaveProductQueryCommand, Product>
    {
        private readonly ICache _cache;

        public SaveProductQuery(EkShopContext dbContext,
            ICache cache)
            : base(dbContext)
        {
            _cache = cache;
        }

        public override async Task<Product> Query(SaveProductQueryCommand command)
        {
            DbContext.AddOrUpdate(command.Product);
            await DbContext.SaveChangesAsync();

            _cache.ClearRegion(CacheRegions.Product);

            return command.Product;
        }
    }
}
