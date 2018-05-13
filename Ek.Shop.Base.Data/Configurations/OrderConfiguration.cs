using Ek.Shop.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.HasIndex(e => e.UserId);

            entity.HasIndex(e => e.VoucherId);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId);

            entity.HasOne(d => d.Voucher)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId);

            entity.HasOne(o => o.Basket)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.BasketId);

            entity.HasOne(o => o.OrderStatus)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.OrderStatusId);

            entity.HasOne(o => o.PaymentMethod)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.PaymentMethodId);

            entity.HasOne(o => o.PaymentMethodType)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.PaymentMethodTypeId);

            entity.HasOne(o => o.ShippingMethod)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.ShippingMethodId);
        }
    }
}
