using Ek.Shop.Domain.InputForms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class InputFormOptionConfiguration : IEntityTypeConfiguration<InputFormOption>
    {
        public void Configure(EntityTypeBuilder<InputFormOption> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.InputFormId);

            entity.HasOne(d => d.InputForm)
                .WithMany(p => p.InputFormOptions)
                .HasForeignKey(d => d.InputFormId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
