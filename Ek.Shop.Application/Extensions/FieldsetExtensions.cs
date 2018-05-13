using Ek.Shop.Application.InputFieldsets;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Extensions;
using Ek.Shop.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ek.Shop.Application.Extensions
{
    public static class FieldsetExtensions
    {
        public static Dictionary<string, InputFieldsetDto> MapToFields<TSource>(this Dictionary<string, InputFieldsetDto> fieldsets, TSource source)
        {
            foreach (var ifieldset in fieldsets)
            {
                var fieldset = ifieldset.Value;
                foreach (var ifield in fieldset.Fields)
                {
                    var field = ifield.Value;
                    var sourceValue = source.GetPropertyValue(ifield.Key)?.ToString();
                    field.Value = sourceValue;
                }
            }

            return fieldsets;
        }

        public static Dictionary<string, DetailError> ValidateFieldsets(this Dictionary<string, InputFieldsetDto> fieldsets)
        {
            var detailErrors = new Dictionary<string, DetailError>();

            foreach (var ifieldset in fieldsets)
            {
                var fieldset = ifieldset.Value;
                foreach (var ifield in fieldset.Fields)
                {
                    var detailErrorKey = ifieldset.Key.FirstLetterToLowerCase() + "." + ifield.Key.FirstLetterToLowerCase();
                    var field = ifield.Value;
                    if (field.Characteristics.Any(o => o.Key == CharacteristicCodes.IsRequired && (bool)o.Value == true)
                        && string.IsNullOrEmpty(field.Value?.ToString())
                        || (field.Characteristics.GetValue(CharacteristicCodes.FieldType)?.ToString() == FieldTypes.Dropdown && field.Value?.ToString() == "0"))
                    {
                        detailErrors.Add(detailErrorKey,
                            new DetailError(DetailErrorTypes.Field, field.Characteristics.GetValue(CharacteristicCodes.IsRequiredMessage)?.ToString() ?? "---"));
                    }
                    else
                    {
                        if (field.Characteristics.Any(o => o.Key == CharacteristicCodes.ValidateMinValue && o.Value.ToDecimal() > field.Value.ToDecimal()))
                        {
                            detailErrors.Add(detailErrorKey,
                                new DetailError(DetailErrorTypes.Field, field.Characteristics.GetValue(CharacteristicCodes.ValidateMinValueMessage)?.ToString()));
                        }
                        if (field.Characteristics.Any(o => o.Key == CharacteristicCodes.ValidateMaxValue && o.Value.ToDecimal() < field.Value.ToDecimal()))
                        {
                            detailErrors.Add(detailErrorKey,
                                new DetailError(DetailErrorTypes.Field, field.Characteristics.GetValue(CharacteristicCodes.ValidateMaxValueMessage)?.ToString()));
                        }
                        if (field.Characteristics.Any(o => o.Key == CharacteristicCodes.ValidateRegexValue && !(new Regex(o.Value.ToString()).IsMatch(field.Value.ToString()))))
                        {
                            detailErrors.Add(detailErrorKey,
                                new DetailError(DetailErrorTypes.Field, field.Characteristics.GetValue(CharacteristicCodes.ValidateRegexValueMessage)?.ToString()));
                        }
                    }
                }
            }

            return detailErrors;
        }
    }
}
