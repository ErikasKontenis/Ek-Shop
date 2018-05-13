using Ek.Shop.Domain.Routes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasOne(o => o.AngularComponent)
                .WithMany(o => o.Routes)
                .HasForeignKey(o => o.AngularComponentId);

            entity.HasOne(o => o.InputForm)
                .WithMany(o => o.Routes)
                .HasForeignKey(o => o.InputFormId);

            entity.HasOne(o => o.Category)
                .WithOne(o => o.Route)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(o => o.Product)
                .WithOne(o => o.Route)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
