using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class CategoryTypeSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<CategoryType>()
            {
                new CategoryType
                {
                    Code = CategoryTypes.Product
                },
                new CategoryType
                {
                    Code = CategoryTypes.Top
                },
                new CategoryType
                {
                    Code = CategoryTypes.Footer
                },
                new CategoryType
                {
                    Code = CategoryTypes.Hidden
                },
                new CategoryType
                {
                    Code = CategoryTypes.TopUser
                },
                new CategoryType
                {
                    Code = CategoryTypes.Left
                }
            });
        }
    }
}
