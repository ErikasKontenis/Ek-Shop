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
    public static class AdminOrdersSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Route>()
            {
                new Route
                {
                    // TODO: AngularComponentId should be AdminOrderComponent
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.ListOrderAdminComponent).Id,
                    Title = "Orders",
                    Url = "orders",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                    Parameter = DatabaseSeedCodes.SalesOrders,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Left).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.Sales).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Orders"
                            },
                        }
                    },
                },
            });

            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Route>()
            {
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.EditOrderAdminComponent).Id,
                    Title = "Order Edit",
                    Url = "edit",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                    Parameter = DatabaseSeedCodes.SalesOrdersEdit,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Left).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.SalesOrders).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Order Edit"
                            },
                        }
                    },
                },
            });
        }
    }
}
