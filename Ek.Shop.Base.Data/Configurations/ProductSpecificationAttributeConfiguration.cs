using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ProductSpecificationAttributeConfiguration : IEntityTypeConfiguration<ProductSpecificationAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductSpecificationAttribute> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.ProductId);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductSpecificationAttributes)
                .HasForeignKey(d => d.ProductId);

            entity.HasOne(o => o.ProductSpecificationAttributeOption)
                .WithMany(o => o.ProductSpecificationAttributes)
                .HasForeignKey(o => o.ProductSpecificationAttributeOptionId);
        }
    }
}
