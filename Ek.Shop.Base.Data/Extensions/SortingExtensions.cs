using Ek.Shop.Domain.Products;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ek.Shop.Core.Extensions
{
    public static class SortingExtensions
    {
        // TODO: Fix this generic type issue
        public static IQueryable<TEntity> OrderByProductSorting<TEntity>(this IQueryable<TEntity> source, string orderByProperty)
            where TEntity : Product

        {
            if (string.IsNullOrEmpty(orderByProperty))
                return source;

            if (orderByProperty.Contains("Characteristics "))
            {
                if (orderByProperty.StartsWith("-"))
                {
                    orderByProperty = orderByProperty.TrimStart('-');
                    var characteristicProperty = orderByProperty.Split(' ')[1];
                    return source.OrderByDescending(o => o.Characteristics.FirstOrDefault(i => i.Characteristic.Code.Equals(characteristicProperty, StringComparison.OrdinalIgnoreCase)).Value);
                }
                else
                {
                    var characteristicProperty = orderByProperty.Split(' ')[1];
                    return source.OrderBy(o => o.Characteristics.FirstOrDefault(i => i.Characteristic.Code.Equals(characteristicProperty, StringComparison.OrdinalIgnoreCase)).Value);
                }
            }
            else
            {
                return source.OrderByDynamic(orderByProperty);
            }
        }

        public static IQueryable<TEntity> OrderByDynamic<TEntity>(this IQueryable<TEntity> source, string orderByProperty)
        {
            string command = "OrderBy";
            if (orderByProperty.StartsWith("-"))
            {
                command = "OrderByDescending";
                orderByProperty = orderByProperty.TrimStart('-');
            }

            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            if (property == null)
            {
                return source;
            }

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}