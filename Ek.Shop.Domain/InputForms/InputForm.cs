using Ek.Shop.Domain.InputFieldsets;
using Ek.Shop.Domain.Routes;
using System.Collections.Generic;

namespace Ek.Shop.Domain.InputForms
{
    public class InputForm : Classifier
    {
        public InputForm()
        {
            InputFieldsets = new HashSet<InputFieldset>();
            InputFormOptions = new HashSet<InputFormOption>();
            Routes = new HashSet<Route>();
        }

        public ICollection<InputFieldset> InputFieldsets { get; set; }

        public ICollection<InputFormOption> InputFormOptions { get; set; }

        public ICollection<Route> Routes { get; set; }
    }
}
