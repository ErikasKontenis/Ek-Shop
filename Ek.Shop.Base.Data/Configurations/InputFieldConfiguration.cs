using Ek.Shop.Domain.InputFields;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class InputFieldConfiguration : IEntityTypeConfiguration<InputField>
    {
        public void Configure(EntityTypeBuilder<InputField> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.InputFieldsetId);

            entity.HasOne(d => d.InputFieldset)
                .WithMany(p => p.InputFields)
                .HasForeignKey(d => d.InputFieldsetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
