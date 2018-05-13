using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.SystemSettings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class SystemSettingsSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<SystemSetting>()
            {
                new SystemSetting
                {
                    Code = SystemSettingOptions.ActiveInputForm.Name,
                    Value = InputFormCodes.Lucid
                },
            });
        }
    }
}
