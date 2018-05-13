using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.InputFields;
using Ek.Shop.Domain.InputForms;
using Ek.Shop.Domain.Products;
using System.Collections.Generic;

namespace Ek.Shop.Domain.InputFieldsets
{
    public class InputFieldset : InputFieldsetBase
    {
        public InputFieldset()
        {
            InputFields = new HashSet<InputField>();
            Characteristics = new HashSet<InputFieldsetCharacteristic>();
        }

        public AngularComponent AngularComponent { get; set; }

        public int? AngularComponentId { get; set; }

        public Category Category { get; set; }

        public int? CategoryId { get; set; }

        public InputForm InputForm { get; set; }

        public int InputFormId { get; set; }

        public ICollection<InputField> InputFields { get; set; }

        public ICollection<InputFieldsetCharacteristic> Characteristics { get; set; }

        public Product Product { get; set; }

        public int? ProductId { get; set; }
    }
}
