using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Categories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ek.Shop.Domain.ClassifierStores
{
    [NotMapped]
    public sealed class ClassifierStore
    {
        public List<AngularComponent> AngularComponents { get; set; }

        public List<CategoryType> CategoryTypes { get; set; }
    }
}
