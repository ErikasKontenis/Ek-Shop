using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Images;
using Ek.Shop.Domain.InputFields;
using Ek.Shop.Domain.InputFieldsets;
using Ek.Shop.Domain.Orders;
using Ek.Shop.Domain.Products;
using System.Collections.Generic;

namespace Ek.Shop.Domain.Characteristics
{
    public class Characteristic : Classifier
    {
        public Characteristic()
        {
            CategoryCharacteristics = new HashSet<CategoryCharacteristic>();
            InputFieldCharacteristics = new HashSet<InputFieldCharacteristic>();
            InputFieldsetCharacteristics = new HashSet<InputFieldsetCharacteristic>();
            ImageCharacteristics = new HashSet<ImageCharacteristic>();
            OrderCharacteristics = new HashSet<OrderCharacteristic>();
            ProductCharacteristics = new HashSet<ProductCharacteristic>();
            ProductDetailCharacteristics = new HashSet<ProductDetailCharacteristic>();
        }

        public ICollection<CategoryCharacteristic> CategoryCharacteristics { get; set; }

        public ICollection<InputFieldCharacteristic> InputFieldCharacteristics { get; set; }

        public ICollection<InputFieldsetCharacteristic> InputFieldsetCharacteristics { get; set; }

        public ICollection<ImageCharacteristic> ImageCharacteristics { get; set; }

        public ICollection<OrderCharacteristic> OrderCharacteristics { get; set; }

        public ICollection<ProductCharacteristic> ProductCharacteristics { get; set; }

        public ICollection<ProductDetailCharacteristic> ProductDetailCharacteristics { get; set; }
    }
}
