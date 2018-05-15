using System.Linq;

namespace StringCompration
{
    public static partial class ComparisonMetrics
    {
        public static double TanimotoCoefficient(this string source, string target)
        {
            double na = source.Length;
            double nb = target.Length;
            double nc = source.Intersect(target).Count();

            return nc / (na + nb - nc);
        }
    }
}
