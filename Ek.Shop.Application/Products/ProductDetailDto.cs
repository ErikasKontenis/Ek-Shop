using System.Collections.Generic;

namespace Ek.Shop.Application.Products
{
    public class ProductDetailDto
    {
        public Dictionary<string, object> Characteristics { get; set; }

        public int Id { get; set; }

        public bool IsOutOfStock { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}
