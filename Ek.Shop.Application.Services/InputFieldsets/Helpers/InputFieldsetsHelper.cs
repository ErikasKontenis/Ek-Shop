using Ek.Shop.Application.InputFields;
using Ek.Shop.Application.InputFieldsets;
using Ek.Shop.Application.Services.Infrastructure.CommonHelpers;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.InputFields;
using Ek.Shop.Domain.InputFieldsets;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Application.Services.InputFieldsets.Helpers
{
    public static class InputFieldsetsHelper
    {
        public static Dictionary<string, InputFieldsetDto> BuildInputFieldsets(List<InputFieldset> inputFieldsets, int workingLanguageId)
        {
            var inputFieldsetsDto = inputFieldsets?.Select(o => new
            {
                Name = o.Code,
                Value = new InputFieldsetDto()
                {
                    Characteristics = CharacteristicsHelper.BuildCharacteristics<InputFieldsetCharacteristic, InputFieldsetCharacteristicTranslation>(o, o.Characteristics, workingLanguageId),
                    Fields = o.InputFields.Select(f => new
                    {
                        Name = f.Code,
                        Value = new InputFieldDto()
                        {
                            Characteristics = CharacteristicsHelper.BuildCharacteristics<InputFieldCharacteristic, InputFieldCharacteristicTranslation>(f, f.Characteristics, workingLanguageId),
                            Value = f.Value
                        }
                    }).OrderBy(i => i.Value.Characteristics.GetValue(CharacteristicCodes.Order)).ToDictionary(key => key.Name, value => value.Value)
                }
            }).OrderBy(i => i.Value.Characteristics.GetValue(CharacteristicCodes.Order)).ToDictionary(key => key.Name, value => value.Value);

            return inputFieldsetsDto;
        }
    }
}
