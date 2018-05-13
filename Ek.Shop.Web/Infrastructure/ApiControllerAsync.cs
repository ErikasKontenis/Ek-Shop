using Ek.Shop.Application.InputFieldsets;
using Ek.Shop.Base.Data.WorkContexts;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Web.Infrastructure
{
    public abstract class ApiControllerAsync : Controller
    {
        protected readonly IQueryProcessor QueryProcessor;
        protected readonly IWorkContext WorkContext;

        public ApiControllerAsync(IBus bus)
        {
            QueryProcessor = bus.QueryProcessor;
            WorkContext = bus.WorkContext;
        }

        protected bool IsFieldsetsValid(Dictionary<string, InputFieldsetDto> fieldsets)
        {
            foreach (var ifieldset in fieldsets)
            {
                var fieldset = ifieldset.Value;
                foreach (var ifield in fieldset.Fields)
                {
                    var field = ifield.Value;
                    if (field.Characteristics.Any(o => o.Key == CharacteristicCodes.IsRequired && (bool)o.Value == true) && string.IsNullOrEmpty(field.Value?.ToString()))
                    {
                        ModelState.AddModelError(ifieldset.Key.FirstLetterToLowerCase() + "." + ifield.Key.FirstLetterToLowerCase(),
                            field.Characteristics.GetValue(CharacteristicCodes.IsRequiredMessage)?.ToString() ?? "The Field Is Required");
                    }
                }
            }

            return ModelState.IsValid;
        }
    }
}
