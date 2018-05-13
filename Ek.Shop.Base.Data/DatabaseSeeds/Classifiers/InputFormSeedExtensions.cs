using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.InputForms;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class InputFormSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<InputForm>()
            {
                new InputForm
                {
                    Code = InputFormCodes.Admin
                },
                new InputForm
                {
                    Code = InputFormCodes.Lucid
                },
                new InputForm
                {
                    Code = InputFormCodes.CommonInputForm
                },
            });
        }
    }
}
