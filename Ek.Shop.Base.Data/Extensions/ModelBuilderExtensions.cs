using Ek.Shop.Application.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace Ek.Shop.Base.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void PluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = InflectorExtensions.Pluralize(entity.DisplayName());
            }
        }

        public static void FormatDecimalPrecision(this ModelBuilder modelBuilder)
        {
            // Impossible with the current core version to ovveride property HasColumnType

            foreach (var propertyBuilder in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?))
                .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType)
                .Property(p.Name)))
                {
                    propertyBuilder.HasColumnType("decimal(10,2)");
                //propertyBuilder.ForSqlServerHasColumnType("decimal(10,2)");
            }
        }
    }
}
