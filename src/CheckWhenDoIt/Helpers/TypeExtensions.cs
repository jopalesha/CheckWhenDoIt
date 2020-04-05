using System.Collections.Generic;
using System.Linq;

namespace Jopalesha.CheckWhenDoIt.Helpers
{
    internal static class TypeExtensions
    {
        internal static bool In<T>(this T value, params T[] values) => values.Contains(value);

        internal static bool In<T>(this T value, IEnumerable<T> values) => values.Contains(value);
    }
}
