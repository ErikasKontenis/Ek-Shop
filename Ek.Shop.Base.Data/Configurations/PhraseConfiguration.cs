using Ek.Shop.Domain.Phrases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class PhraseConfiguration : IEntityTypeConfiguration<Phrase>
    {
        public void Configure(EntityTypeBuilder<Phrase> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Value)
                .HasColumnType("text");

            entity.HasOne(o => o.Language)
                .WithMany(o => o.Phrases)
                .HasForeignKey(o => o.LanguageId);
        }
    }
}
