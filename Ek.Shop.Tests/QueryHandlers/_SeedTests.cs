using Ek.Shop.Base.Data.DatabaseSeeds.Client;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Domain.AngularComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Ek.Shop.Tests.QueryHandlers
{
    [TestClass]
    public class _SeedTests : TestUtil
    {
        [TestMethod]
        public void _ShouldSeedDb()
        {
            var isDbSeeded = true;
            // If there is no angular components in the table then the default seed is required
            if (!DbContext.Set<AngularComponent>().Any())
            {
                try
                {
                    DbContext.Seed();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            var randomGenerateProducts = false;
            if (randomGenerateProducts) {
                for (var i = 0; i < 20000; i++)
                    ClientProductSeedExtensions.Seed(DbContext);
            }
           
            Assert.IsTrue(isDbSeeded);
        }
    }
}
