using Ek.Shop.Domain.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class LocaleLanguageResourceConfiguration : IEntityTypeConfiguration<LocaleLanguageResource>
    {
        public void Configure(EntityTypeBuilder<LocaleLanguageResource> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(r => r.Code)
                .HasMaxLength(255);

            entity.HasIndex(o => new { o.Code, o.LanguageId }).IsUnique();

            entity.HasOne(o => o.Language)
                .WithMany(o => o.LocaleLanguageResources)
                .HasForeignKey(o => o.LanguageId);
        }
    }
}
