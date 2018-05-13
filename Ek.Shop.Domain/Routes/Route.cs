using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.InputForms;
using Ek.Shop.Domain.Products;

namespace Ek.Shop.Domain.Routes
{
    public class Route : Entity
    {
        public Route()
        { }

        public virtual AngularComponent AngularComponent { get; set; }

        public int AngularComponentId { get; set; }

        public Category Category { get; set; }

        public string Description { get; set; }

        public virtual InputForm InputForm { get; set; }

        public int InputFormId { get; set; }

        public string Parameter { get; set; }

        public Product Product { get; set; }

        public string RedirectTo { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}
