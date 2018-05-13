using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Characteristics;
using Ek.Shop.Domain.Images;
using Ek.Shop.Domain.InputForms;
using Ek.Shop.Domain.Languages;
using Ek.Shop.Domain.Routes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Client
{
    public static class ClientCategorySeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Route>()
            {
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.ProductCategoryComponent).Id,
                    Title = "Bloknotai",
                    Url = "bloknotai",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Parameter = DatabaseSeedCodes.NoteBooks,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Product).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.PaperProducts).Id,
                        Images = new List<Image>()
                        {
                            new Image
                            {
                                ImageSizeTypeId = dbContext.Set<ImageSizeType>().FirstOrDefault(o => o.Code == ImageSizeTypes.Small).Id,
                                Url = "bloknotai.png",
                                Characteristics = new List<ImageCharacteristic>()
                                {
                                    new ImageCharacteristic
                                    {
                                        CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                        Translations = new List<ImageCharacteristicTranslation>()
                                        {
                                            new ImageCharacteristicTranslation()
                                            {
                                                LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                                                Value = "Random alt tagas"
                                            },
                                            new ImageCharacteristicTranslation()
                                            {
                                                LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                                                Value = "Random alt tag"
                                            }
                                        },
                                    }
                                },
                            },
                        },
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
                                        Value = "Bloknotai"
                                    },
                                    new CategoryCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                                        Value = "Notebooks"
                                    }
                                },
                            },
                        }
                    },
                },
                new Route
                {
                    AngularComponentId = dbContext.Set<AngularComponent>().FirstOrDefault(o => o.Code == AngularComponents.ProductCategoryComponent).Id,
                    Title = "Lipnūs Lapeliai",
                    Url = "lipnus-lapeliai",
                    InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                    Parameter = DatabaseSeedCodes.StickyNotes,
                    Category = new Category
                    {
                        CategoryTypeId = dbContext.Set<CategoryType>().FirstOrDefault(o => o.Code == CategoryTypes.Product).Id,
                        ParentId = dbContext.Set<Category>().FirstOrDefault(o => o.Route.Parameter == DatabaseSeedCodes.PaperProducts).Id,
                        Images = new List<Image>()
                        {
                            new Image
                            {
                                ImageSizeTypeId = dbContext.Set<ImageSizeType>().FirstOrDefault(o => o.Code == ImageSizeTypes.Small).Id,
                                Url = "lipnus_lapeliai.png"
                            }
                        },
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
                                        Value = "Lipnūs lapeliai"
                                    },
                                    new CategoryCharacteristicTranslation()
                                    {
                                        LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                                        Value = "Sticky notes"
                                    }
                                }
                            },
                        }
                    },
                },
            });
        }
    }
}
