using Ek.Shop.Domain.Images;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ImageCharacteristicConfiguration : IEntityTypeConfiguration<ImageCharacteristic>
    {
        public void Configure(EntityTypeBuilder<ImageCharacteristic> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.ImageId);

            entity.HasOne(d => d.Image)
                .WithMany(p => p.Characteristics)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Characteristic)
                .WithMany(p => p.ImageCharacteristics)
                .HasForeignKey(d => d.CharacteristicId);

            entity.HasMany(d => d.Translations)
                .WithOne(p => p.Characteristic)
                .HasForeignKey(d => d.CharacteristicId);
        }
    }
}
