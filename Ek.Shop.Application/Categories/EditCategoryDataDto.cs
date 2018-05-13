using System.Collections.Generic;

namespace Ek.Shop.Application.Classifiers
{
    public class EditCategoryDataDto
    {
        public List<AngularComponentDto> AngularComponents { get; set; }

        public CategoryDto Category { get; set; }

        public List<CategoryTypeDto> CategoryTypes { get; set; }

        public List<CategoryClassifierDto> ParentCategories { get; set; }
    }
}
