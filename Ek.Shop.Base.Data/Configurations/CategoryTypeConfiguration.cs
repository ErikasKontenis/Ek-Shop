using Ek.Shop.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> entity)
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
