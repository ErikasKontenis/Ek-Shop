using Ek.Shop.Domain.Characteristics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class CharacteristicConfiguration : IEntityTypeConfiguration<Characteristic>
    {
        public void Configure(EntityTypeBuilder<Characteristic> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(r => r.Code)
                .HasMaxLength(255);

            entity.HasIndex(e => e.Code)
                .IsUnique();
        }
    }
}
