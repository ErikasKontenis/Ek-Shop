using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Images;
using Ek.Shop.Domain.InputFields;
using Ek.Shop.Domain.InputFieldsets;
using Ek.Shop.Domain.Orders;
using Ek.Shop.Domain.Phrases;
using Ek.Shop.Domain.Products;
using System.Collections.Generic;

namespace Ek.Shop.Domain.Languages
{
    public class Language : Classifier
    {
        public Language()
        {
            CategoryCharacteristicTranslations = new HashSet<CategoryCharacteristicTranslation>();
            InputFieldCharacteristicTranslations = new HashSet<InputFieldCharacteristicTranslation>();
            InputFieldsetCharacteristicTranslations = new HashSet<InputFieldsetCharacteristicTranslation>();
            ImageCharacteristicTranslations = new HashSet<ImageCharacteristicTranslation>();
            OrderCharacteristicTranslations = new HashSet<OrderCharacteristicTranslation>();
            ProductCharacteristicTranslations = new HashSet<ProductCharacteristicTranslation>();
            ProductDetailCharacteristicTranslations = new HashSet<ProductDetailCharacteristicTranslation>();
            LocaleLanguageResources = new HashSet<LocaleLanguageResource>();

            Phrases = new HashSet<Phrase>();
        }

        public ICollection<CategoryCharacteristicTranslation> CategoryCharacteristicTranslations { get; set; }

        public ICollection<InputFieldCharacteristicTranslation> InputFieldCharacteristicTranslations { get; set; }

        public ICollection<InputFieldsetCharacteristicTranslation> InputFieldsetCharacteristicTranslations { get; set; }

        public ICollection<ImageCharacteristicTranslation> ImageCharacteristicTranslations { get; set; }

        public ICollection<ProductCharacteristicTranslation> ProductCharacteristicTranslations { get; set; }

        public ICollection<ProductDetailCharacteristicTranslation> ProductDetailCharacteristicTranslations { get; set; }

        public ICollection<OrderCharacteristicTranslation> OrderCharacteristicTranslations { get; set; }

        public ICollection<LocaleLanguageResource> LocaleLanguageResources { get; set; }

        public ICollection<Phrase> Phrases { get; set; }
    }
}
