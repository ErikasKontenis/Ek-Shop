using Ek.Shop.Domain.Images;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class ImageSizeTypeConfiguration : IEntityTypeConfiguration<ImageSizeType>
    {
        public void Configure(EntityTypeBuilder<ImageSizeType> entity)
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
