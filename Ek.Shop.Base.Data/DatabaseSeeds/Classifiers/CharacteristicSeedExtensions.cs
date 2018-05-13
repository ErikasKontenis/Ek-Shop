using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Characteristics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class CharacteristicSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Characteristic>()
            {
                new Characteristic
                {
                    Code = CharacteristicCodes.AccessLevel
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.Name
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.Description
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.BreadcrumbName
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.NavigationName
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.AltInfo
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.Parameter
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.ValidateMaxValueMessage
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.ValidateMinValueMessage
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.HtmlType
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.IsDisabled
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.IsHidden
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.ValidateMaxValue
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.ValidateMinValue
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.Label
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.PrimaryCssClass
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.IsRequired
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.IsRequiredMessage
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.Characteristic
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.FieldType
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.ApiUrl
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.Placeholder
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.Order
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.Url
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.UrlQuery
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.PopoverFocusButton
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.PopoverMessage
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.PopoverTitle
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.IsYesNoPopoverRequired
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.NgRepeatCssClass
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.ValidateRegexValue
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.ValidateRegexValueMessage
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.IsShowHomePage
                },
                new Characteristic
                {
                    Code = CharacteristicCodes.IconClass
                },
            });
        }
    }
}
