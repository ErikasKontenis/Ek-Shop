using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Extensions;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Products
{
    public class ListProductsByCategoryQuery : RemoteQuery<ListProductsByCategoryCommand, PagedList<Product>>
    {
        public ListProductsByCategoryQuery(EkShopContext dbContext)
            : base (dbContext)
        { }

        public override async Task<PagedList<Product>> Query(ListProductsByCategoryCommand command)
        {
            var includableQueryable = DbContext.Products
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent)
                .Include(o => o.Images).ThenInclude(o => o.ImageSizeType)
                .Include(o => o.ProductDetails).ThenInclude(o => o.ProductDetailType)
                .Include(o => o.ProductDetails).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.ProductDetails).ThenInclude(o => o.Characteristics)
                .Include(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Characteristics);

            IQueryable<Product> queryable = null;
            if (command.CategoryId.HasValue)
                queryable = includableQueryable.Where(o => o.CategoryId == command.CategoryId);
            if (command.IsShowHomePage)
                queryable = includableQueryable.Where(o => o.Characteristics.Any(i => i.Characteristic.Code == CharacteristicCodes.IsShowHomePage && i.Value == "true"));

            var pagedList = await queryable.OrderByProductSorting(command.Sorting).ToPagedListAsync(command);

            var productCharacteristicIds = pagedList.Items.SelectMany(o => o.Characteristics).Select(o => o.Id);
            await DbContext.ProductCharacteristicTranslations.Where(o => productCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var productDetailCharacteristicIds = pagedList.Items.SelectMany(o => o.ProductDetails).SelectMany(o => o.Characteristics).Select(o => o.Id);
            await DbContext.ProductDetailCharacteristicTranslations.Where(o => productDetailCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var productImageCharacteristicIds = pagedList.Items.SelectMany(o => o.Images).SelectMany(o => o.Characteristics).Select(o => o.Id);
            await DbContext.ImageCharacteristicTranslations.Where(o => productImageCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            return pagedList;
        }
    }
}
