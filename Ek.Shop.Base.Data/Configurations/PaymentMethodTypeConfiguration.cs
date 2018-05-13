using Ek.Shop.Domain.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class PaymentMethodTypeConfiguration : IEntityTypeConfiguration<PaymentMethodType>
    {
        public void Configure(EntityTypeBuilder<PaymentMethodType> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(o => o.Code);

            entity.HasMany(o => o.Orders)
                .WithOne(o => o.PaymentMethodType)
                .HasForeignKey(o => o.PaymentMethodTypeId);

            entity.HasOne(o => o.PaymentMethod)
                .WithMany(o => o.PaymentMethodTypes)
                .HasForeignKey(o => o.PaymentMethodId);
        }
    }
}
