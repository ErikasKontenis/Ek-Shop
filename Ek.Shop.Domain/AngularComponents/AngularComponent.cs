using Ek.Shop.Domain.InputFieldsets;
using Ek.Shop.Domain.Routes;
using System.Collections.Generic;

namespace Ek.Shop.Domain.AngularComponents
{
    public class AngularComponent : Classifier
    {
        public AngularComponent()
        {
            InputFieldsets = new HashSet<InputFieldset>();
            Routes = new HashSet<Route>();
        }

        public ICollection<InputFieldset> InputFieldsets { get; set; }

        public ICollection<Route> Routes { get; set; }
    }
}
