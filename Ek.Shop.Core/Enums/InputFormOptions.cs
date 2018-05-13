using Ek.Shop.Core.Models;

namespace Ek.Shop.Core.Enums
{
    public static class InputFormOptions
    {
        // Sitas propertis admin paneleje tures tiesiog irasyti kategorijos url + value
        public static Option<string> BaseCategoryUrl = new Option<string>
            ("bazinis_kategorijos_url", string.Empty);

        // Sitas propertis admin paneleje tures tiesiog irasyti produkto url + value
        public static Option<string> BaseProductUrl = new Option<string>
            ("bazinis_produkto_url", string.Empty);
    }
}
