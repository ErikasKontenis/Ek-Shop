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

namespace Ek.Shop.Base.Data.DatabaseSeeds.Admin.Components
{
    public static class ListCategoryAdminComponentSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<AngularComponent>()
            {
                new AngularComponent
                {
                    Code = AngularComponents.ListCategoryAdminComponent,
                    InputFieldsets = new List<InputFieldset>()
                    {
                        new InputFieldset
                        {
                            Code = "CategoryPagination",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
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
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.UrlQuery).Id,
                                            Value = "page"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Parameter).Id,
                                            Value = "{ \"firstText\": \"First\", \"lastText\": \"Last\", \"previousText\": \"Previous\", \"nextText\": \"Next\" }"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "PageSize",
                                    Value = "12",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Dropdown
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.UrlQuery).Id,
                                            Value = "pagesize"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Parameter).Id,
                                            Value = "{ \"items\": [ { \"value\": 1, \"text\": \"Items per page\", \"isHeader\": true }, { \"value\": 6, \"text\": \"6\", \"isHeader\": false }, { \"value\": 12, \"text\": \"12\", \"isHeader\": false }, { \"value\": 24, \"text\": \"24\", \"isHeader\": false }, { \"value\": 36, \"text\": \"36\", \"isHeader\": false } ] }"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.PrimaryCssClass).Id,
                                            Value = "pagination-button"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "CategoryHeaderLeft",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "Search",
                                    Characteristics = new List<InputFieldCharacteristic>
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Searchbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.UrlQuery).Id,
                                            Value = "filtername"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Placeholder).Id,
                                            Value = "Search for category"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "CategoryHeaderRight",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "Create",
                                    Characteristics = new List<InputFieldCharacteristic>
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Button
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                            Value = "Add New"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.PrimaryCssClass).Id,
                                            Value = "btn btn-primary float-right"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Url).Id,
                                            Value = "/admin/catalog/categories/edit"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "PrimaryTableHeader",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "Name",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                            Value = "Name"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "IsPublished",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                            Value = "Published"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "Action",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                            Value = "Action"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "PrimaryTableActions",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "Edit",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Button
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.PrimaryCssClass).Id,
                                            Value = "btn btn-link"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Url).Id,
                                            Value = "/admin/catalog/categories/edit"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                            Value = "Edit"
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
