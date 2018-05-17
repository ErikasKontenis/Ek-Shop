using Ek.Shop.Application.Extensions;
using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.Queries;
using Ek.Shop.Base.Data.Queries.RemoteQueries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ek.Shop.Data.Products
{
    public class GetProductQuery : RemoteQuery<GetProductCommand, Product>
    {
        private readonly IQuery<GetCategoryCommand, Category> _getCategoryBaseQuery;

        public GetProductQuery(EkShopContext dbContext,
            IQuery<GetCategoryCommand, Category> getCategoryBaseQuery)
            : base (dbContext)
        {
            _getCategoryBaseQuery = getCategoryBaseQuery;
        }

        public override async Task<Product> Query(GetProductCommand command)
        {
            var product = await DbContext.Products
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.Characteristics)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.InputFields).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent).ThenInclude(o => o.InputFieldsets).ThenInclude(o => o.InputFields).ThenInclude(o => o.Characteristics)
                .Include(o => o.Fieldsets).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Fieldsets).ThenInclude(o => o.Characteristics)
                .Include(o => o.Fieldsets).ThenInclude(o => o.InputFields).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Fieldsets).ThenInclude(o => o.InputFields).ThenInclude(o => o.Characteristics)
                .Include(o => o.Images).ThenInclude(o => o.ImageSizeType)
                .Include(o => o.Images).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Images).ThenInclude(o => o.Characteristics)
                .Include(o => o.ProductDetails).ThenInclude(o => o.ProductDetailType)
                .Include(o => o.ProductDetails).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.ProductDetails).ThenInclude(o => o.Characteristics)
                .Include(o => o.ProductRatings)
                .Include(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Characteristics)
                .FirstOrDefaultAsync(o => o.Id == command.ProductId);

            if (product == null)
            {
                return null;
            }

            // TODO: find better way to get similarProducts
            string randomString = CreateMD5(product.Id.ToString());
            product.SimilarProducts = await DbContext.Products.Where(o => o.CategoryId == product.CategoryId && o.Id != product.Id)
                .OrderByDescending(o => randomString).Take(4).ToListAsync();

            var categoryNodeResults = _getCategoryBaseQuery.Execute(new GetCategoryCommand(product.CategoryId, command.LanguageId)).ToList();
            product.Category = categoryNodeResults.FirstOrDefault(o => o.Id == product.CategoryId);

            var categoryCharacteristicIds = product.Category.FromRootToNode().SelectMany(o => o.Characteristics).Select(o => o.Id);
            await DbContext.CategoryCharacteristicTranslations.Where(o => categoryCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var productCharacteristicIds = product.Characteristics.Select(o => o.Id);
            await DbContext.ProductCharacteristicTranslations.Where(o => productCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var productDetailCharacteristicIds = product.ProductDetails.SelectMany(o => o.Characteristics).Select(o => o.Id);
            await DbContext.ProductDetailCharacteristicTranslations.Where(o => productDetailCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var productImageCharacteristicIds = product.Images.SelectMany(o => o.Characteristics).Select(o => o.Id);
            await DbContext.ImageCharacteristicTranslations.Where(o => productImageCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var inputFieldsetCharacteristicIds = product.Fieldsets.SelectMany(o => o.Characteristics).Select(o => o.Id).Union(product.Route.AngularComponent.InputFieldsets.SelectMany(o => o.Characteristics).Select(o => o.Id));
            await DbContext.InputFieldsetCharacteristicTranslations.Where(o => inputFieldsetCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            var inputFieldCharacteristicIds = product.Fieldsets.SelectMany(o => o.InputFields).SelectMany(o => o.Characteristics).Select(o => o.Id).Union(product.Route.AngularComponent.InputFieldsets.SelectMany(o => o.InputFields).SelectMany(o => o.Characteristics).Select(o => o.Id));
            await DbContext.InputFieldCharacteristicTranslations.Where(o => inputFieldCharacteristicIds.Contains(o.CharacteristicId) && o.LanguageId == command.LanguageId).LoadAsync();

            return product;
        }

        private string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
