using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Languages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class LanguageSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Language>()
            {
                new Language
                {
                    Code = Languages.Lithuanian,
                },
                new Language
                {
                    Code = Languages.English,
                }
            });
        }
    }
}
