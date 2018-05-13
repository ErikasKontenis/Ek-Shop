using Ek.Shop.Domain.Characteristics;
using System.Collections.Generic;

namespace Ek.Shop.Domain
{
    public abstract class CharacteristicBase<TCharacteristicTranslation> : Entity, ICharacteristicBase
        where TCharacteristicTranslation : CharacteristicTranslation
    {
        public CharacteristicBase()
        {
            Translations = new HashSet<TCharacteristicTranslation>();
        }

        public Characteristic Characteristic { get; set; }

        public int CharacteristicId { get; set; }

        public ICollection<TCharacteristicTranslation> Translations { get; set; }

        public string Value { get; set; }
    }

    public interface ICharacteristicBase
    {
        Characteristic Characteristic { get; set; }

        int CharacteristicId { get; set; }

        string Value { get; set; }
    }
}
