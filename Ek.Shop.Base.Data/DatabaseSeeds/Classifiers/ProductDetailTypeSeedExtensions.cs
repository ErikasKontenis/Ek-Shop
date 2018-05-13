using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class ProductDetailTypeSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<ProductDetailType>()
            {
                new ProductDetailType
                {
                    Code = ProductDetailTypes.ColorId
                },
                new ProductDetailType
                {
                    Code = ProductDetailTypes.Url
                }
            });
        }
    }
}
