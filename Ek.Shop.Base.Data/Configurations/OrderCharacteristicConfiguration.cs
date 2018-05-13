using Ek.Shop.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class OrderCharacteristicConfiguration : IEntityTypeConfiguration<OrderCharacteristic>
    {
        public void Configure(EntityTypeBuilder<OrderCharacteristic> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.OrderId);

            entity.HasOne(d => d.Order)
                .WithMany(p => p.Characteristics)
                .HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.Characteristic)
                .WithMany(p => p.OrderCharacteristics)
                .HasForeignKey(d => d.CharacteristicId);

            entity.HasMany(d => d.Translations)
                .WithOne(p => p.Characteristic)
                .HasForeignKey(d => d.CharacteristicId);
        }
    }
}
