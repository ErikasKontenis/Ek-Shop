using Ek.Shop.Domain.AngularComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class AngularComponentConfiguration : IEntityTypeConfiguration<AngularComponent>
    {
        public void Configure(EntityTypeBuilder<AngularComponent> entity)
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
