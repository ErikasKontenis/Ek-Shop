using Ek.Shop.Base.Data.Caches;
using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Products
{
    public class DeleteProductQuery : RemoteQuery<DeleteProductCommand, Product>
    {
        private readonly ICache _cache;

        public DeleteProductQuery(EkShopContext dbContext,
            ICache cache)
            : base(dbContext)
        {
            _cache = cache;
        }

        public override bool IsCacheRequired => false;

        public override async Task<Product> Query(DeleteProductCommand command)
        {
            var product = await DbContext.Products.Include(o => o.Route).FirstOrDefaultAsync(o => o.Id == command.ProductId);
            if (product == null)
            {
                return null;
            }

            DbContext.ActionByEntityState(product.Route, EntityState.Deleted);
            await DbContext.SaveChangesAsync();

            _cache.ClearRegion(CacheRegions.Product);

            return product;
        }
    }
}
