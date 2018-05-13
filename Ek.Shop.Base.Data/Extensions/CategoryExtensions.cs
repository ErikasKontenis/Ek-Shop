using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Categories;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Base.Data.Extensions
{
    public static class CategoryExtensions
    {
        public static IEnumerable<Category> DistinctByActiveInputForm(this IEnumerable<Category> categories, IWorkContext workContext)
        {
            foreach (var category in categories)
            {
                foreach (var inputFieldset in category.Route.AngularComponent.InputFieldsets.ToList())
                {
                    if (inputFieldset.InputFormId != workContext.WorkingInputFormId && inputFieldset.InputForm.Code != InputFormCodes.CommonInputForm)
                    {
                        category.Route.AngularComponent.InputFieldsets.Remove(inputFieldset);
                    }
                }
            }

            // If there is two fieldsets with same name from commonInputForm and active input form then remove the commonInputForm fieldset
            foreach (var category in categories)
            {
                foreach (var inputFieldset in category.Route.AngularComponent.InputFieldsets.ToList())
                {
                    if (inputFieldset.InputForm.Code == InputFormCodes.CommonInputForm
                        && category.Route.AngularComponent.InputFieldsets.Any(o => o.Code == inputFieldset.Code && o.InputForm.Code != InputFormCodes.CommonInputForm))
                    {
                        category.Route.AngularComponent.InputFieldsets.Remove(inputFieldset);
                    }
                }
            }

            return categories;
        }
    }
}
