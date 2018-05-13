using Ek.Shop.Application.Abstractions;
using Ek.Shop.Application.Images;
using Ek.Shop.Application.Products;
using Ek.Shop.Core.Models;
using System.Collections.Generic;

namespace Ek.Shop.Application.Classifiers
{
    public class CategoryDto : ComponentDto
    {
        public string CategoryTypeCode { get; set; }

        public Dictionary<string, string> Characteristics { get; set; }

        public int Id { get; set; }

        public List<ImageDto> Images { get; set; }

        public List<CategoryNavigationDto> Navigations { get; set; }

        public Dictionary<string, object> Parameters { get; set; }

        public int? ParentId { get; set; }

        public PagedList<ProductDto> Products { get; set; }

        public PagedList<CategoryDto> SubCategories { get; set; }
    }
}
