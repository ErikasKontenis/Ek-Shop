using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ProductSpecificationAttributeOptionConfiguration : IEntityTypeConfiguration<ProductSpecificationAttributeOption>
    {
        public void Configure(EntityTypeBuilder<ProductSpecificationAttributeOption> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasMany(d => d.ProductSpecificationAttributes)
                .WithOne(p => p.ProductSpecificationAttributeOption)
                .HasForeignKey(d => d.ProductSpecificationAttributeOptionId);
        }
    }
}
