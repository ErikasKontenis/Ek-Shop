using System;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Core.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Removes from the target collection all elements that match the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the target collection.</typeparam>
        /// <param name="collection">The target collection.</param>
        /// <param name="match">The predicate used to match elements.</param>
        /// <exception cref="ArgumentNullException">
        /// The target collection is a null reference.
        /// <br />-or-<br />
        /// The match predicate is a null reference.
        /// </exception>
        /// <returns>Returns the number of elements removed.</returns>
        public static int RemoveAll<T>(this ICollection<T> collection, Predicate<T> match)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            if (match == null)
                throw new ArgumentNullException("match");

            int count = 0;

            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (match(collection.ElementAt(i)))
                {
                    collection.Remove(collection.ElementAt(i));
                    count++;
                }
            }

            return count;
        }
    }
}
