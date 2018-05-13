using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ProductCharacteristicConfiguration : IEntityTypeConfiguration<ProductCharacteristic>
    {
        public void Configure(EntityTypeBuilder<ProductCharacteristic> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.ProductId);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.Characteristics)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Characteristic)
                .WithMany(p => p.ProductCharacteristics)
                .HasForeignKey(d => d.CharacteristicId);

            entity.HasMany(d => d.Translations)
                .WithOne(p => p.Characteristic)
                .HasForeignKey(d => d.CharacteristicId);
        }
    }
}
