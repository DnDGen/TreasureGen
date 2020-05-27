using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit
{
    public static class AssertionExtensions
    {
        public static bool IsEquivalent<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            if (source == null || target == null)
            {
                return source == target;
            }

            return source.Count() == target.Count()
                && !source.Except(target).Any()
                && !target.Except(source).Any();
        }
    }
}
