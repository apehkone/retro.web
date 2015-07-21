using System;
using System.Collections.Generic;
using System.Linq;

namespace Retro.Web.Security
{
    internal static class Extensions
    {
        internal static IList<T> ToIList<T>(this IEnumerable<T> enumerable) {
            return enumerable.ToList();
        }

        public static IList<T> Remove<T>(this IList<T> collection, Func<T, bool> predicate) {
            foreach (var s in collection.Where(predicate).ToList()) {
                collection.Remove(s);
            }
            return collection;
        }
    }
}