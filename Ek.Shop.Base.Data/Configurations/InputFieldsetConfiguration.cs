using Ek.Shop.Domain.InputFieldsets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class InputFieldsetConfiguration : IEntityTypeConfiguration<InputFieldset>
    {
        public void Configure(EntityTypeBuilder<InputFieldset> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.AngularComponentId);

            entity.HasIndex(e => e.CategoryId);

            entity.HasIndex(e => e.InputFormId);

            entity.HasIndex(e => e.ProductId);

            entity.HasOne(d => d.AngularComponent)
                .WithMany(p => p.InputFieldsets)
                .HasForeignKey(d => d.AngularComponentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Fieldsets)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.InputForm)
                .WithMany(p => p.InputFieldsets)
                .HasForeignKey(d => d.InputFormId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.Fieldsets)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
