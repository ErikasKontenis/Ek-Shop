using Ek.Shop.Domain.Baskets;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Routes;
using System.Collections.Generic;

namespace Ek.Shop.Domain.Products
{
    public class Product : RouteComponent
    {
        public Product()
            : base()
        {
            BasketItems = new HashSet<BasketItem>();
            Characteristics = new HashSet<ProductCharacteristic>();
            ProductDetails = new HashSet<ProductDetail>();
            ProductRatings = new HashSet<ProductRating>();
            ProductReviews = new HashSet<ProductReview>();
            ProductSpecificationAttributes = new HashSet<ProductSpecificationAttribute>();
        }

        public ICollection<BasketItem> BasketItems { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public ICollection<ProductCharacteristic> Characteristics { get; set; }

        public decimal Discount { get; set; }
        
        public decimal Price { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }

        public ICollection<ProductRating> ProductRatings { get; set; }

        public ICollection<ProductReview> ProductReviews { get; set; }

        public ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; set; }

        public Route Route { get; set; }

        public int RouteId { get; set; }

        public ICollection<Product> SimilarProducts { get; set; }

        public decimal GetTotalPrice()
        {
            return Price - Discount;
        }
    }
}
