using Ek.Shop.Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.UserId);

            entity.HasOne(d => d.User)
                .WithMany(p => p.Baskets)
                .HasForeignKey(d => d.UserId);

            entity.HasMany(o => o.Orders)
                .WithOne(o => o.Basket)
                .HasForeignKey(o => o.BasketId);
        }
    }
}
