using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.CategoryId);

            entity.Property(e => e.Discount).HasColumnType("decimal(10, 2)");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(o => o.Route)
                .WithOne(o => o.Product)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Images)
                .WithOne(e => e.Product)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.ProductSpecificationAttributes)
                .WithOne(e => e.Product)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Ignore(e => e.SimilarProducts);
        }
    }
}
