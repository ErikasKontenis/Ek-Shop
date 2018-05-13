using System.Collections.Generic;

namespace Ek.Shop.Domain
{
    public interface ICharacteristic<TCharacteristic, TCharacteristicTranslation>
        where TCharacteristicTranslation : CharacteristicTranslation
        where TCharacteristic : CharacteristicBase<TCharacteristicTranslation>
    {
        ICollection<TCharacteristic> Characteristics { get; set; }
    }
}
