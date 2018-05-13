using Ek.Shop.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ek.Shop.Base.Data.Extensions
{
    public static class DatabaseExtensions
    {
        // TODO [EF] This may be replaced by a first class mechanism in EF
        public static void ActionByEntityState<TDbContext, TEntity>(this TDbContext dbContext, TEntity entity, EntityState entityState)
            where TDbContext : DbContext
            where TEntity : class
        {
            switch (entityState)
            {
                case EntityState.Detached:
                    dbContext.Add(entity);
                    break;
                case EntityState.Modified:
                    dbContext.Update(entity);
                    break;
                case EntityState.Added:
                    dbContext.Add(entity);
                    break;
                case EntityState.Deleted:
                    dbContext.Remove(entity);
                    break;
                case EntityState.Unchanged:
                    //item already in db no need to do anything  
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // TODO [EF] This may be replaced by a first class mechanism in EF
        public static void AddOrUpdate<TDbContext, TEntity>(this TDbContext dbContext, TEntity entity)
            where TDbContext : DbContext
            where TEntity : Entity
        {
            var entityState = entity.Id > 0 ? EntityState.Modified : EntityState.Added;

            dbContext.ActionByEntityState(entity, entityState);
        }

        public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> source, int levelIndex, Expression<Func<TEntity, TEntity>> expression)
            where TEntity : Entity
        {
            if (levelIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(levelIndex));
            var member = (MemberExpression)expression.Body;
            var property = member.Member.Name;
            var sb = new StringBuilder();
            for (int i = 0; i < levelIndex; i++)
            {
                if (i > 0)
                    sb.Append(Type.Delimiter);
                sb.Append(property);
            }
            return source.Include(sb.ToString());
        }
    }
}
