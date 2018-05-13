using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Characteristics;
using Ek.Shop.Domain.InputForms;
using Ek.Shop.Domain.Routes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Client
{
    public static class ClientSub1CategorySeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Route>()
            {
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.SubCategoryComponent).Id,
                    Title = "Kanceliarinės prekės",
                    Url = "kanceliarines-prekes",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Parameter = DatabaseSeedCodes.Stationary,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Product).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.Home).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Kanceliarinės prekės",
                            },
                        }
                    },
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.SubCategoryComponent).Id,
                    Title = "Info",
                    Url = "info",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Parameter = DatabaseSeedCodes.Info,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Top).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.Home).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Info",
                            },
                        }
                    },
                },
            });
        }
    }
}
