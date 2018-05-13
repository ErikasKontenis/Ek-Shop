using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Languages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Locales
{
    public static class EnglishLanguageResourceSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<LocaleLanguageResource>()
            {
                new LocaleLanguageResource
                {
                    Code = AngularComponents.AddCategoryAdminComponent,
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Value = "labai gerai"
                },
            });
        }
    }
}
