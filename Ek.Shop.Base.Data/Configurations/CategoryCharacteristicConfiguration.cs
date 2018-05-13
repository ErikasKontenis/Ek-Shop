using Ek.Shop.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class CategoryCharacteristicConfiguration : IEntityTypeConfiguration<CategoryCharacteristic>
    {
        public void Configure(EntityTypeBuilder<CategoryCharacteristic> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.CategoryId);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Characteristics)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Characteristic)
                .WithMany(p => p.CategoryCharacteristics)
                .HasForeignKey(d => d.CharacteristicId);

            entity.HasMany(d => d.Translations)
                .WithOne(p => p.Characteristic)
                .HasForeignKey(d => d.CharacteristicId);
        }
    }
}
