using Ek.Shop.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethod>
    {
        public void Configure(EntityTypeBuilder<ShippingMethod> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(o => o.Code);

            entity.HasMany(o => o.Orders)
                .WithOne(o => o.ShippingMethod)
                .HasForeignKey(o => o.ShippingMethodId);
        }
    }
}
