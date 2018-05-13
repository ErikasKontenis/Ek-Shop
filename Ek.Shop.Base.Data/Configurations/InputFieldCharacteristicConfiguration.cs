using Ek.Shop.Domain.InputFields;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class InputFieldCharacteristicConfiguration : IEntityTypeConfiguration<InputFieldCharacteristic>
    {
        public void Configure(EntityTypeBuilder<InputFieldCharacteristic> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.InputFieldId);

            entity.HasOne(d => d.InputField)
                .WithMany(p => p.Characteristics)
                .HasForeignKey(d => d.InputFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Characteristic)
                .WithMany(p => p.InputFieldCharacteristics)
                .HasForeignKey(d => d.CharacteristicId);

            entity.HasMany(d => d.Translations)
                .WithOne(p => p.Characteristic)
                .HasForeignKey(d => d.CharacteristicId);
        }
    }
}
