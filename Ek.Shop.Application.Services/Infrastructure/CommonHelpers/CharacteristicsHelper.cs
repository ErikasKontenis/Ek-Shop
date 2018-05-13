using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Extensions;
using Ek.Shop.Domain;
using Ek.Shop.Domain.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Application.Services.Infrastructure.CommonHelpers
{
    public static class CharacteristicsHelper
    {
        public static Dictionary<string, object> BuildCharacteristics<TCharacteristic, TCharacteristicTranslation>(object source, ICollection<TCharacteristic> characteristics, int workingLanguageId)
            where TCharacteristicTranslation : CharacteristicTranslation
            where TCharacteristic : CharacteristicBase<TCharacteristicTranslation>
        {
            return characteristics.Select(o => new
            {
                Name = o.Characteristic.Code,
                Value = o.BuildPhrase<TCharacteristic, TCharacteristicTranslation>(characteristics, source, workingLanguageId)
            }).ToDictionary(key => key.Name, value => value.Value);
        }

        public static void MergeCharacteristics<TCharacteristics>(this ICollection<TCharacteristics> source, List<Characteristic> availableCharacteristics, Dictionary<string, string> characteristics)
            where TCharacteristics : ICharacteristicBase, new()
        {
            characteristics.ClearEmptyCharacteristics();
            source.RemoveAllByKeys(characteristics?.Select(o => o.Key));
            if (characteristics.IsNullOrEmpty())
            {
                return;
            }

            foreach (var characteristic in characteristics)
            {
                var sourceCharacteristic = source.FirstOrDefault(o => o.Characteristic.Code == characteristic.Key);
                if (sourceCharacteristic != null)
                {
                    sourceCharacteristic.Value = characteristic.Value;
                }
                else
                {
                    var newCharacteristic = new TCharacteristics()
                    {
                        Characteristic = availableCharacteristics.FirstOrDefault(o => o.Code == characteristic.Key),
                        Value = characteristic.Value
                    };
                    source.Add(newCharacteristic);
                }
            }
        }

        public static void RemoveAllByKeys<TCharacteristics>(this ICollection<TCharacteristics> characteristics, IEnumerable<string> keyCollection)
            where TCharacteristics : ICharacteristicBase
        {
            if (keyCollection.IsNullOrEmpty())
            {
                characteristics.Clear();
                return;
            }


            characteristics.RemoveAll(o => !keyCollection.Contains(o.Characteristic.Code));
        }

        public static void ClearEmptyCharacteristics(this Dictionary<string, string> characteristics)
        {
            if (characteristics.IsNullOrEmpty())
                return;

            var nullCharacteristics = characteristics.Where(pair => string.IsNullOrEmpty(pair.Value) || pair.Value.Equals("false", StringComparison.OrdinalIgnoreCase))
                        .Select(pair => pair.Key)
                        .ToList();

            foreach (var nullCharacteristic in nullCharacteristics)
            {
                characteristics.Remove(nullCharacteristic);
            }
        }

        private static object BuildPhrase<TCharacteristic, TCharacteristicTranslation>(this TCharacteristic characteristic, ICollection<TCharacteristic> characteristics, object source, int workingLanguageId)
            where TCharacteristicTranslation : CharacteristicTranslation
            where TCharacteristic : CharacteristicBase<TCharacteristicTranslation>
        {
            var phrase = characteristic.Translations.FirstOrDefault(o => o.LanguageId == workingLanguageId)?.Value ?? characteristic.Value;
            if (string.IsNullOrEmpty(phrase))
            {
                return phrase;
            }

            var interpolatedStringArguments = phrase.GetInterpolatedStringArguments();
            foreach (var argument in interpolatedStringArguments)
            {
                if (argument.Contains("Characteristics."))
                {
                    var characteristicProperty = argument.Split('.')[1];
                    var characteristicPhrase = characteristics.FirstOrDefault(o => o.Characteristic.Code.Equals(characteristicProperty, StringComparison.OrdinalIgnoreCase))?.Value;
                    phrase = phrase.Replace("{" + argument + "}", characteristicPhrase);
                }
                else
                {
                    var value = source.GetPropertyValue(argument)?.ToString();
                    if (value != null)
                    {
                        phrase = phrase.Replace("{" + argument + "}", value);
                    }
                }
            }

            return phrase.ToObject();
        }

        private static object ToObject(this string value)
        {
            int intValue;
            decimal decimalValue;
            if (value == null || string.Equals(value, "null", StringComparison.OrdinalIgnoreCase))
                return null;
            else if (string.Equals(value, "false", StringComparison.OrdinalIgnoreCase))
                return false;
            else if (string.Equals(value, "true", StringComparison.OrdinalIgnoreCase))
                return true;
            else if (int.TryParse(value, out intValue))
                return intValue;
            else if (decimal.TryParse(value, out decimalValue))
                return decimalValue;

            return value;
        }
    }
}