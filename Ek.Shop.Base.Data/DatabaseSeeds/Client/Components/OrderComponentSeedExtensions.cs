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
    public static class OrderComponentSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<AngularComponent>()
            {
                new AngularComponent
                {
                    Code = AngularComponents.OrderComponent,
                    InputFieldsets = new List<InputFieldset>()
                    {
                        new InputFieldset
                        {
                            Code = "ShippingInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Pristatymas"
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
                                            Value = FieldTypes.Radio
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.NgRepeatCssClass).Id,
                                            Value = "shipping-method"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "1"
                                        },
                                    }
                                },
                            }
                        },
                        new InputFieldset
                        {
                            Code = "BillingInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Duomenys"
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
                                            Value = "Vardas"
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
                                            Value = "Pavardė"
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
                                            Value = "El. paštas"
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
                                            Value = "Telefono nr."
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },

                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequiredMessage).Id,
                                            Value = "Truputi kitokia privalkė"
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
                                            Value = "Perka įmonė?"
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
                                            Value = "Įmonės pavadinimas"
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
                                            Value = "Įmonės kodas"
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
                                            Value = "Įmonės PVM kodas"
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
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Pristatymo duomenys"
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
                                            Value = "Adresas"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text,
                                        },

                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequiredMessage).Id,
                                            Value = "Laukelis adresas yra privalomas."
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
                                    Code = "City",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Miestas"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },

                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequiredMessage).Id,
                                            Value = "Laukelis miestas yra privalomas."
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
                                    Code = "PostCode",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Pašto kodas"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Number
                                        },

                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequiredMessage).Id,
                                            Value = "Laukelis pašto kodas yra privalomas."
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
                            }
                        },
                        new InputFieldset
                        {
                            Code = "BillingAdditionalInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Apmokėjimas"
                                },
                            },
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "AdditionalInfo",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Pastabos"
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
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Placeholder).Id,
                                            Value = "Papildoma informacija prie užsakymo"
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
                            Code = "PaymentInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Apmokėjimas"
                                },
                            },
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "PaymentMethod",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Radio
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.NgRepeatCssClass).Id,
                                            Value = "payment-method"
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
                                    Code = "PaymentMethodType",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Radio
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.NgRepeatCssClass).Id,
                                            Value = "payment-method-type"
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
                            Code = "OrderInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.CommonInputForm).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Užsakymo informacija"
                                },
                            },
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "TotalBasketPrice",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Krepšelio suma:"
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
                                    Code = "TotalBasketVat",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Viso PVM:"
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
                                    Code = "ShippingPrice",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Pristatymas:"
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
                                    Code = "SubmitOrder",
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
                                            Value = "Baigti užsakymą"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "4"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.PrimaryCssClass).Id,
                                            Value = "btn btn-success"
                                        },
                                    }
                                },
                            }
                        },
                    },
                },
            });
        }
    }
}
