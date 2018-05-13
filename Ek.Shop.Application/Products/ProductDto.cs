using Ek.Shop.Application.Abstractions;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Images;
using System.Collections.Generic;

namespace Ek.Shop.Application.Products
{
    public class ProductDto : ComponentDto
    {
        public int CategoryId { get; set; }

        public int Id { get; set; }

        public List<ImageDto> Images { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public List<CategoryNavigationDto> Navigations { get; set; }

        public Dictionary<string, string> Characteristics { get; set; }

        public List<ProductDetailDto> ProductDetails { get; set; }

        public List<ProductDto> SimilarProducts { get; set; }

        public int Rating { get; set; }
    }
}
