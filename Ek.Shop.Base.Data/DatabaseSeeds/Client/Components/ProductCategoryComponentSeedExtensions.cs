using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Characteristics;
using Ek.Shop.Domain.InputFields;
using Ek.Shop.Domain.InputFieldsets;
using Ek.Shop.Domain.InputForms;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Client.Components
{
    public static class ProductCategoryComponentSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<AngularComponent>()
            {
                new AngularComponent
                {
                    Code = AngularComponents.ProductCategoryComponent,
                    InputFieldsets = new List<InputFieldset>()
                    {
                        new InputFieldset
                        {
                            Code = "BaseProductCategoryHeader",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "Sorting",
                                    Value = "0",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Dropdown
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Parameter).Id,
                                            Value = "{ \"items\": [ { \"value\": \"0\", \"text\": \"Rikiavimas\", \"isHeader\": true }, { \"value\": \"Price\", \"text\": \"Pigiausi viršuje\", \"isHeader\": false }, { \"value\": \"-Price\", \"text\": \"Brangiausi viršuje\", \"isHeader\": false }, { \"value\": \"Characteristics+Name\", \"text\": \"A-Ž (pagal abėcelę)\", \"isHeader\": false }, { \"value\": \"-Characteristics+Name\", \"text\": \"Ž-A (pagal abėcelę)\", \"isHeader\": false } ] }"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.UrlQuery).Id,
                                            Value = "sorting"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "PageSize",
                                    Value = "36",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Dropdown
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Parameter).Id,
                                            Value = "{ \"items\": [ { \"value\": 1, \"text\": \"Rodyti po\", \"isHeader\": true }, { \"value\": 12, \"text\": \"12\", \"isHeader\": false }, { \"value\": 24, \"text\": \"24\", \"isHeader\": false }, { \"value\": 36, \"text\": \"36\", \"isHeader\": false } ] }"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.UrlQuery).Id,
                                            Value = "pagesize"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "CategoryPagination",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "Pagination",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Pagination
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Parameter).Id,
                                            Value = "{ \"firstText\": \"Pirmas\", \"lastText\": \"Paskutinis\", \"previousText\": \"Ankstesnis\", \"nextText\": \"Sekantis\" }"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.UrlQuery).Id,
                                            Value = "page"
                                        },
                                    }
                                },
                            }
                        },
                    }
                },
            });
        }
    }
}
