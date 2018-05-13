using Ek.Shop.Domain.Images;
using Ek.Shop.Domain.InputFieldsets;
using System.Collections.Generic;

namespace Ek.Shop.Domain
{
    /// <summary>
    /// The origin of this class is to serve the basic objects of the Product and Category entities.
    /// </summary>
    public abstract class RouteComponent : Classifier
    {
        public RouteComponent()
        {
            Fieldsets = new HashSet<InputFieldset>();
            Images = new HashSet<Image>();
        }

        public ICollection<InputFieldset> Fieldsets { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
