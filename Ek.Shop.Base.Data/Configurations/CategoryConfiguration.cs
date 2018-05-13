using Ek.Shop.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasOne(o => o.Route)
                .WithOne(o => o.Category)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Children)
                .WithOne(e => e.Parent)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(o => o.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Images)
                .WithOne(e => e.Category)
                .HasForeignKey(o => o.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
