using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Products;
using System.Collections.Generic;

namespace Ek.Shop.Domain.Images
{
    public class Image : Entity
    {
        public Image()
        {
            Characteristics = new HashSet<ImageCharacteristic>();
        }

        public Category Category { get; set; }

        public int? CategoryId { get; set; }

        public ICollection<ImageCharacteristic> Characteristics { get; set; }

        public ImageSizeType ImageSizeType { get; set; }

        public int ImageSizeTypeId { get; set; }

        public Product Product { get; set; }

        public int? ProductId { get; set; }

        public string Url { get; set; }
    }
}
