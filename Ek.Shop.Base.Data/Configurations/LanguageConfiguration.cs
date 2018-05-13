using Ek.Shop.Domain.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(r => r.Code)
                .HasMaxLength(255);

            entity.HasIndex(e => e.Code)
                .IsUnique();

            entity.HasMany(o => o.LocaleLanguageResources)
                .WithOne(o => o.Language)
                .HasForeignKey(o => o.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
