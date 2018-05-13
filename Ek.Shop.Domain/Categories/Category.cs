using Ek.Shop.Application.Extensions;
using Ek.Shop.Domain.Products;
using Ek.Shop.Domain.Routes;
using System.Collections.Generic;

namespace Ek.Shop.Domain.Categories
{
    public class Category : RouteComponent, ITreeNode<Category>
    {
        public Category()
            : base()
        {
            Characteristics = new HashSet<CategoryCharacteristic>();
            Products = new HashSet<Product>();
        }

        public CategoryType CategoryType { get; set; }

        public int CategoryTypeId { get; set; }

        public ICollection<CategoryCharacteristic> Characteristics { get; set; }

        public IList<Category> Children { get; set; }

        public string Parameter { get; set; }

        public Category Parent { get; set; }

        public int? ParentId { get; set; }

        public ICollection<Product> Products { get; set; }

        public Route Route { get; set; }

        public int RouteId { get; set; }
    }
}
