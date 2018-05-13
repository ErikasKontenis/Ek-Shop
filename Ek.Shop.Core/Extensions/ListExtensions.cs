using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using Ek.Shop.Core.Resources;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Contracts.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Determines whether the collection is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The IEnumerable type.</typeparam>
        /// <param name="enumerable">The enumerable, which may be null or empty.</param>
        /// <returns>
        ///     true if the IEnumerable is null or empty; otherwise, false.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return true;

            return !enumerable.Any();
        }

        public static Dictionary<string, DetailError> ToHeaderErrors(this IEnumerable<string> enumerable)
        {
            var detailErrors = new Dictionary<string, DetailError>();
            if (enumerable.IsNullOrEmpty())
                return detailErrors;

            for (var i = 0; i < enumerable.Count(); i++)
            {
                detailErrors.Add(Fields.HeaderErrors + i, new DetailError(DetailErrorTypes.HeaderErrors, enumerable.ElementAt(i)));
            }

            return detailErrors;
        }

        public static bool IsEnumerable<T>(this T source)
        {
            return typeof(IEnumerable).IsAssignableFrom(source.GetType());
        }
    }
}
