using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.ProductId);

            entity.HasIndex(e => e.UserId);

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.Property(e => e.IsConfirmed).HasDefaultValueSql("0");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.User)
                .WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.UserId);
        }
    }
}
