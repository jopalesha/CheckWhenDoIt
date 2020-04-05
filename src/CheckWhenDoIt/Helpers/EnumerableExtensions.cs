using System.Collections;

namespace Jopalesha.CheckWhenDoIt.Helpers
{
    internal static class EnumerableExtensions
    {
        internal static bool IsNullOrEmpty(this IEnumerable items) =>
            items == null ||
            (items as ICollection)?.Count == 0 ||
            !items.GetEnumerator().MoveNext();
    }
}
