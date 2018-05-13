using Ek.Shop.Domain.Images;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ek.Shop.Base.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.HasIndex(e => e.ProductId);

            entity.Property(e => e.Url);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.ProductId);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Images)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId);

            entity.HasOne(o => o.ImageSizeType)
                .WithMany(o => o.Images)
                .HasForeignKey(o => o.ImageSizeTypeId);
        }
    }
}
