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
    public static class EditOrderAdminComponentSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<AngularComponent>()
            {
                new AngularComponent
                {
                    Code = AngularComponents.EditOrderAdminComponent,
                    InputFieldsets = new List<InputFieldset>()
                    {
                        new InputFieldset
                        {
                            Code = "AdditionalInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Info"
                                },
                            },
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "ShippingMethod",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Dropdown
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Shipping method"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
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
                                    Code = "PaymentMethod",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Dropdown
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Payment method"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
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
                                    Code = "PaymentMethodType",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Dropdown
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Payment method type"
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
                                    Code = "OrderStatus",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Dropdown
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Order status"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "4"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "BillingInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Billing Info"
                                },
                            },
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "Name",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Name"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
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
                                    Code = "LastName",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Last name"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
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
                                    Code = "Email",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Email"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
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
                                    Code = "PhoneNumber",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Phone"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },

                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequiredMessage).Id,
                                            Value = "Required field"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
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
                                    Code = "IsBuyerCompany",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Is buyer company"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Checkbox
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
                                    Code = "CompanyName",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Company name"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "6"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "CompanyCode",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Comany code"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "7"
                                        },
                                    }
                                },
                                new InputField
                                {
                                    Code = "CompanyVat",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Company VAT"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "8"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "BillingShippingInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Shipping Info"
                                },
                            },
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "Address",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Address"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
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
                                    Code = "City",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "City"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
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
                                    Code = "PostCode",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Post code"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Number
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "3"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "BasketInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Basket Info"
                                },
                            },
                            InputFields = new List<InputField>()
                            {
  
                            }
                        },
                        new InputFieldset
                        {
                            Code = "BasketInfoTableHeader",
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
                                            Value = "Product name"
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
                                    Code = "Quantity",
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
                                            Value = "Quantity"
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
                                    Code = "Price",
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
                                            Value = "Price"
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
                                            Value = "4"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "OrderFooterActions",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "Save",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Button
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                            Value = "Save"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.PrimaryCssClass).Id,
                                            Value = "btn btn-success"
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
                                    Code = "Cancel",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Button
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                            Value = "Cancel"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.PrimaryCssClass).Id,
                                            Value = "btn btn-primary"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "2"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "CategoryHeader",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id
                        },
                    }
                },
            });
        }
    }
}
