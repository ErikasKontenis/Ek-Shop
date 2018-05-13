using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class ShippingMethodSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<ShippingMethod>()
            {
                new ShippingMethod
                {
                    Code = ShippingMethods.Courier,
                    Price = 4.99M
                },
                new ShippingMethod
                {
                    Code = ShippingMethods.Shop,
                    Price = 0.00M
                },
            });
        }
    }
}
