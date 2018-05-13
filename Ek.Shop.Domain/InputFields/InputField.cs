using Ek.Shop.Domain.InputFieldsets;
using System.Collections.Generic;

namespace Ek.Shop.Domain.InputFields
{
    public class InputField : InputFieldsetBase
    {
        public InputField()
        {
            Characteristics = new HashSet<InputFieldCharacteristic>();
        }

        public InputFieldset InputFieldset { get; set; }

        public int InputFieldsetId { get; set; }

        public ICollection<InputFieldCharacteristic> Characteristics { get; set; }
    }
}
