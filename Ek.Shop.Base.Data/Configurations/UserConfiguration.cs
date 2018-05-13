using Ek.Shop.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Ignore(o => o.Roles);

            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasDefaultValueSql("'1900-01-01T00:00:00.000'");
        }
    }
}
