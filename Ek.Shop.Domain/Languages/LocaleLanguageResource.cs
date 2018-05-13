namespace Ek.Shop.Domain.Languages
{
    public class LocaleLanguageResource : Classifier
    {
        public LocaleLanguageResource()
        { }

        public Language Language { get; set; }

        public int LanguageId { get; set; }
    }
}
