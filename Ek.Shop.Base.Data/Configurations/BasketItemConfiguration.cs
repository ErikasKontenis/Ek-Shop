using Ek.Shop.Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.BasketId);

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.Property(e => e.ProductDetailId);

            entity.HasOne(d => d.Basket)
                .WithMany(p => p.BasketItems)
                .HasForeignKey(d => d.BasketId);

            entity.HasOne(d => d.ProductDetail)
                .WithMany(p => p.BasketItems)
                .HasPrincipalKey(d => d.Id)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.BasketItems)
                .HasPrincipalKey(d => d.Id)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
