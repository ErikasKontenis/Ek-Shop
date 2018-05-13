using System.Collections.Generic;

namespace Ek.Shop.Domain.Categories
{
    public class CategoryType : Classifier
    {
        public CategoryType()
        {
            Categories = new HashSet<Category>();
        }

        public ICollection<Category> Categories { get; set; }
    }
}
