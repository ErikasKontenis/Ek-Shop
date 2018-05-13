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
    public class ListOrderAdminComponentSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<AngularComponent>()
            {
                new AngularComponent
                {
                    Code = AngularComponents.ListOrderAdminComponent,
                    InputFieldsets = new List<InputFieldset>()
                    {
                        new InputFieldset
                        {
                            Code = "OrderPagination",
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
                            Code = "OrderHeaderLeft",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "OrderId",
                                    Characteristics = new List<InputFieldCharacteristic>
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Order id"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Number
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.UrlQuery).Id,
                                            Value = "filteroderid"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "1"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "BillingName",
                                    Characteristics = new List<InputFieldCharacteristic>
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Billing name"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.UrlQuery).Id,
                                            Value = "filterbillingname"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "2"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "BillingLastName",
                                    Characteristics = new List<InputFieldCharacteristic>
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Billing last name"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.UrlQuery).Id,
                                            Value = "filterbillinglastname"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "3"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "BillingEmail",
                                    Characteristics = new List<InputFieldCharacteristic>
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Billing email"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.UrlQuery).Id,
                                            Value = "filterbillingemail"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "4"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "SubmitSearch",
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
                                            Value = "Search"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.PrimaryCssClass).Id,
                                            Value = "btn btn-primary"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "5"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "OrderHeaderRight",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            InputFields = new List<InputField>()
                            {

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
                                    Code = "Id",
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
                                            Value = "Order #"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "1"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "OrderStatus",
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
                                            Value = "Order Status"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "2"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "Customer",
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
                                            Value = "Customer"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "3"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "CreatedOn",
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
                                            Value = "Created on"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "4"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "TotalPrice",
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
                                            Value = "Total price"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "5"
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
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "6"
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
                                            Value = "/admin/sales/orders/edit"
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
