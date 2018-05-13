using Ek.Shop.Domain.InputFieldsets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class InputFieldsetCharacteristicConfiguration : IEntityTypeConfiguration<InputFieldsetCharacteristic>
    {
        public void Configure(EntityTypeBuilder<InputFieldsetCharacteristic> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.InputFieldsetId);

            entity.HasOne(d => d.InputFieldset)
                .WithMany(p => p.Characteristics)
                .HasForeignKey(d => d.InputFieldsetId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Characteristic)
                .WithMany(p => p.InputFieldsetCharacteristics)
                .HasForeignKey(d => d.CharacteristicId);

            entity.HasMany(d => d.Translations)
                .WithOne(p => p.Characteristic)
                .HasForeignKey(d => d.CharacteristicId);
        }
    }
}
