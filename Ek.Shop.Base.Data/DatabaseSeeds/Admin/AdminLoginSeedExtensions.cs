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

namespace Ek.Shop.Base.Data.DatabaseSeeds.Admin
{
    public static class AdminLoginSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Route>()
            {
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.LoginComponent).Id,
                    Title = "Admin Login",
                    Url = "login",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Product).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.Admin).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Admin Login"
                            },
                        }
                    },
                },
            });
        }
    }
}
