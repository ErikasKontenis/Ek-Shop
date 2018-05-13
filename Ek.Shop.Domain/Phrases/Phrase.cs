using Ek.Shop.Domain.Languages;

namespace Ek.Shop.Domain.Phrases
{
    public class Phrase : Classifier
    {
        public Phrase()
        { }

        public Language Language { get; set; }

        public int? LanguageId { get; set; }
    }
}
