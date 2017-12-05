using System.Linq;

namespace StringCompration.Core
{
    public static partial class ComparisonMetrics
    {
        public static double HammingDistance(this string source, string target)
        {
            if (source.Length != target.Length) return 9999;

            return source.Where((t, i) => !t.Equals(target[i])).Count();
        }
    }
}