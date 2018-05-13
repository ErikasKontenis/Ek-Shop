using Ek.Shop.Domain.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(o => o.Code);

            entity.HasMany(o => o.Orders)
                .WithOne(o => o.PaymentMethod)
                .HasForeignKey(o => o.PaymentMethodId);

            entity.HasMany(o => o.PaymentMethodTypes)
                .WithOne(o => o.PaymentMethod)
                .HasForeignKey(o => o.PaymentMethodId);
        }
    }
}
