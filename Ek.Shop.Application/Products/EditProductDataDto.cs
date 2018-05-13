using Ek.Shop.Application.Classifiers;
using System.Collections.Generic;

namespace Ek.Shop.Application.Products
{
    public class EditProductDataDto
    {
        public List<AngularComponentDto> AngularComponents { get; set; }

        public ProductDto Product { get; set; }

        public List<CategoryClassifierDto> Categories { get; set; }
    }
}
