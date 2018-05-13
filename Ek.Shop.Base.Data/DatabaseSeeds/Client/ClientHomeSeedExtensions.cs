using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Characteristics;
using Ek.Shop.Domain.InputForms;
using Ek.Shop.Domain.Languages;
using Ek.Shop.Domain.Routes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Client
{
    public static class ClientHomeSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Route>()
            {
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.HomeComponent).Id,
                    Title = "Titulinis",
                    Url = string.Empty,
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Parameter = DatabaseSeedCodes.Home,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Product).Id,
                        Characteristics = new List<CategoryCharacteristic>()
                        {
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                Translations = new List<CategoryCharacteristicTranslation>()
                                {
                                    new CategoryCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "Prekių katalogas"
                                    },
                                    new CategoryCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                                        Value = "Products catalog"
                                    }
                                },
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.BreadcrumbName).Id,
                                Translations = new List<CategoryCharacteristicTranslation>()
                                {
                                    new CategoryCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "Titulinis"
                                    },
                                    new CategoryCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                                        Value = "Home"
                                    }
                                },
                            },
                            new CategoryCharacteristic
                            {
                                CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Description).Id,
                                Translations = new List<CategoryCharacteristicTranslation>()
                                {
                                    new CategoryCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                        Value = "<h1><center>Produktų sąrašas su charakteristiką: IsShowHomePage</center></h1>"
                                    }
                                }
                            }
                        }
                    },
                },
            });
        }
    }
}
