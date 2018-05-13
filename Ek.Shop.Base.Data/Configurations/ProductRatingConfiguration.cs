using Ek.Shop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ProductRatingConfiguration : IEntityTypeConfiguration<ProductRating>
    {
        public void Configure(EntityTypeBuilder<ProductRating> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.ProductId);

            entity.HasIndex(e => e.UserId);

            entity.Property(e => e.ProductId);

            entity.Property(e => e.UserId);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductRatings)
                .HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.User)
                .WithMany(p => p.ProductRatings)
                .HasForeignKey(d => d.UserId);
        }
    }
}
