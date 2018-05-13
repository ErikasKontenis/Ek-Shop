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
    class EditProductAdminComponentSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<AngularComponent>()
            {
                new AngularComponent
                {
                    Code = AngularComponents.EditProductAdminComponent,
                    InputFieldsets = new List<InputFieldset>()
                    {
                        new InputFieldset
                        {
                            Code = "ProductInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Product Info"
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
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Characteristic).Id,
                                            Value = CharacteristicCodes.Name
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.ClassifierTextbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.ApiUrl).Id,
                                            Value = "/classifier/getPhrasesByTerm"
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
                                    Code = "Description",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Description"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Characteristic).Id,
                                            Value = CharacteristicCodes.Description
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.HtmlEditor
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
                                    Code = "CategoryId",
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
                                            Value = "Category"
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
                                    Code = "AngularComponentCode",
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
                                            Value = "Product Type"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequiredMessage).Id,
                                            Value = "Very important field is required."
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "4"
                                        },
                                    },
                                },
                                new InputField
                                {
                                    Code = "Order",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Order"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Number
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Characteristic).Id,
                                            Value = CharacteristicCodes.Order
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
                                    Code = "Price",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Price (Eur)"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Number
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequired).Id,
                                            Value = "true"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsRequiredMessage).Id,
                                            Value = "The price field is required."
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "6"
                                        },
                                    },
                                },
                                new InputField
                                {
                                    Code = "Discount",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Amount To Discount (Eur)"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Number
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Order).Id,
                                            Value = "7"
                                        },
                                    },
                                },
                                new InputField
                                {
                                    Code = "IsDisabled",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Checkbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Is Published"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Characteristic).Id,
                                            Value = CharacteristicCodes.IsDisabled
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
                            Code = "ProductSeo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "SEO"
                                },
                            },
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "Title",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Meta title"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
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
                                    Code = "Description",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Meta description"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
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
                                    Code = "Url",
                                    Value = string.Empty,
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "SEO friendly url"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Textbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
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
                            Code = "FooterActions", // ProductFooterActions?
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
                                new InputField
                                {
                                    Code = "Delete",
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
                                            Value = "Delete"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.PrimaryCssClass).Id,
                                            Value = "btn btn-danger"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.PopoverTitle).Id,
                                            Value = "Are you sure?"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.PopoverMessage).Id,
                                            Value = "This action will delete all possible details with the product. Are you sure you want to delete this product?"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.IsYesNoPopoverRequired).Id,
                                            Value = "true"
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
                            Code = "ProductAdditionalInfo",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "Additional Info"
                                },
                            },
                            InputFields = new List<InputField>()
                            {
                                new InputField
                                {
                                    Code = "BreadcrumbName",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Breadcrumb Name"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Characteristic).Id,
                                            Value = CharacteristicCodes.BreadcrumbName
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.ClassifierTextbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.ApiUrl).Id,
                                            Value = "/classifier/getPhrasesByTerm"
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
                                    Code = "NavigationName",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Navigation Name"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.HtmlType).Id,
                                            Value = HtmlTypes.Text
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Characteristic).Id,
                                            Value = CharacteristicCodes.NavigationName
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.ClassifierTextbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.ApiUrl).Id,
                                            Value = "/classifier/getPhrasesByTerm"
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
                                    Code = "IsShowHomePage",
                                    Characteristics = new List<InputFieldCharacteristic>()
                                    {
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.FieldType).Id,
                                            Value = FieldTypes.Checkbox
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Label).Id,
                                            Value = "Show on home page"
                                        },
                                        new InputFieldCharacteristic
                                        {
                                            CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Characteristic).Id,
                                            Value = CharacteristicCodes.IsShowHomePage
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
                            Code = "ProductInputFields",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id,
                            Characteristics = new List<InputFieldsetCharacteristic>()
                            {
                                new InputFieldsetCharacteristic
                                {
                                    CharacteristicId = dbContext.Set<Characteristic>().FirstOrDefault(o => o.Code == CharacteristicCodes.Name).Id,
                                    Value = "UI Elements"
                                },
                            },
                        },
                        new InputFieldset
                        {
                            Code = "ProductHeader",
                            InputFormId = dbContext.Set<InputForm>().FirstOrDefault(o => o.Code == InputFormCodes.Admin).Id
                        },
                    }
                },
            });
        }
    }
}
