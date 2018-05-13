using Ek.Shop.Domain.Languages;

namespace Ek.Shop.Domain
{
    public abstract class CharacteristicTranslation : Classifier
    {
        public Language Language { get; set; }

        public int? LanguageId { get; set; }
    }
}
