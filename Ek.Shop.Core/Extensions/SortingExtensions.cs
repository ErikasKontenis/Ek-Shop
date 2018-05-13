using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ek.Shop.Core.Extensions
{
    public static class SortingExtensions
    {
        //public static IEnumerable<TSource> ToSortedList<TSource, TCommand>(this IEnumerable<TSource> source, string sorting)
        //{
        //    if (string.IsNullOrEmpty(sorting))
        //        return source;

        //    if (sorting.StartsWith("+"))
        //    {
        //        source.OrderBy(o => o.)
        //    }

        //    var totalItemsCount = source.Count();
        //    var sourceList = source.Skip((command.PageIndex - 1) * command.PageSize).Take(command.PageSize);
        //    return new PagedList<TSource>(sourceList, command.PageIndex, command.PageSize, totalItemsCount);
        //}

        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty)
        {
            string command = "OrderBy";
            if (orderByProperty.StartsWith("-"))
            {
                command = "OrderByDescending";
                orderByProperty = orderByProperty.TrimStart('-');
            }

            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}
