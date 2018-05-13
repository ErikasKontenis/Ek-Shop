using System.Collections.Generic;

namespace Ek.Shop.Application.Languages
{
    public class LanguageDto
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public List<LocaleLanguageResourceDto> LocaleLanguageResources { get; set; }
    }
}
