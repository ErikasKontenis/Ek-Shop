using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ProductDetailCharacteristicConfiguration : IEntityTypeConfiguration<ProductDetailCharacteristic>
    {
        public void Configure(EntityTypeBuilder<ProductDetailCharacteristic> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.ProductDetailId);

            entity.HasOne(d => d.ProductDetail)
                .WithMany(p => p.Characteristics)
                .HasPrincipalKey(d => d.Id);

            entity.HasOne(d => d.Characteristic)
                .WithMany(p => p.ProductDetailCharacteristics)
                .HasForeignKey(d => d.CharacteristicId);

            entity.HasMany(d => d.Translations)
                .WithOne(p => p.Characteristic)
                .HasForeignKey(d => d.CharacteristicId);
        }
    }
}
