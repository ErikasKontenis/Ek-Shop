using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.ProductId);

            entity.Property(e => e.ProductId);

            entity.Property(e => e.IsOutOfStock).HasDefaultValueSql("0");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductId);

            entity.HasOne(o => o.ProductDetailType)
                .WithMany(o => o.ProductDetails)
                .HasForeignKey(o => o.ProductDetailTypeId);
        }
    }
}
