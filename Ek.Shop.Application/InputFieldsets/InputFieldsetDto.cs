using Ek.Shop.Application.InputFields;
using System.Collections.Generic;

namespace Ek.Shop.Application.InputFieldsets
{
    public class InputFieldsetDto
    {
        public Dictionary<string, object> Characteristics { get; set; }

        public Dictionary<string, InputFieldDto> Fields { get; set; }
    }
}
