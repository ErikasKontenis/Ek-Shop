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
    public static class ClientUserSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Route>()
            {
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.SubCategoryComponent).Id,
                    Title = "Vartotojo sąsaja",
                    Url = "vartotojas",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Parameter = DatabaseSeedCodes.ClientUser,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.TopUser).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.Home).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Vartotojo sąsaja"
                            },
                        }
                    },
                },
            });

            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Route>()
            {
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.LoginComponent).Id,
                    Title = "Prisijungimas",
                    Url = "Prisijungimas",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.TopUser).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.ClientUser).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Prisijungimas"
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.AccessLevel).Id,
                                Value = AccessLevels.OnlyGuest
                            },
                        }
                    },
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.RegistrationComponent).Id,
                    Title = "Registracija",
                    Url = "registracija",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.TopUser).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.ClientUser).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Registracija"
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.AccessLevel).Id,
                                Value = AccessLevels.OnlyGuest
                            },
                        },
                    },
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.ProfileComponent).Id,
                    Title = "Profilis",
                    Url = "profilis",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.TopUser).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.ClientUser).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Profilis"
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.AccessLevel).Id,
                                Value = AccessLevels.OnlyAuthenticated
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                Value = "2"
                            },
                        },
                    },
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.BasketComponent).Id,
                    Title = "Krepšelis",
                    Url = "krepselis",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.TopUser).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.ClientUser).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Krepšelis"
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.AccessLevel).Id,
                                Value = AccessLevels.OnlyAuthenticated
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                Value = "1"
                            },
                        },
                    },
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.OrderComponent).Id,
                    Title = "Atsiskaitymas",
                    Url = "atsiskaitymas",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Hidden).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.ClientUser).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Atsiskaitymas"
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.AccessLevel).Id,
                                Value = AccessLevels.OnlyAuthenticated
                            },
                        },
                    },
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.LogoutComponent).Id,
                    Title = "Atsijungti",
                    Url = "atsijungti",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.TopUser).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.ClientUser).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Value = "Atsijungti"
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.AccessLevel).Id,
                                Value = AccessLevels.OnlyAuthenticated
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                Value = "3"
                            },
                        },
                    },
                },
            });
        }
    }
}
