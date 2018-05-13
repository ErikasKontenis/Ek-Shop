using Ek.Shop.Application.InputFields;
using Ek.Shop.Application.InputFieldsets;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Application.Abstractions
{
    public abstract class ComponentDto : MetaDto
    {
        public string AngularComponentCode { get; set; }

        public string Code { get; set; }

        public Dictionary<string, InputFieldsetDto> Fieldsets { get; set; }

        public int InputFormId { get; set; }

        public InputFieldDto GetAnyField(string fieldId)
        {
            return Fieldsets.SelectMany(o => o.Value.Fields).FirstOrDefault(o => o.Key == fieldId).Value;
        }
    }
}
