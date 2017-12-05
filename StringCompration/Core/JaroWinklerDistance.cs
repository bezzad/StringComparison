using System;

namespace StringCompration.Core
{
    public static partial class ComparisonMetrics
    {
        public static double JaroWinklerDistance(this string source, string target)
        {
            var jaroDistance = source.JaroDistance(target);
            var commonPrefixLength = CommonPrefixLength(source, target);

            return jaroDistance + (commonPrefixLength * 0.1 * (1 - jaroDistance));
        }

        public static double JaroWinklerDistanceWithPrefixScale(string source, string target, double p)
        {
            var prefixScale = 0.1;

            if (p > 0.25) { prefixScale = 0.25; } // The maximu value for distance to not exceed 1
            else if (p < 0) { prefixScale = 0; } // The Jaro Distance
            else { prefixScale = p; }

            var jaroDistance = source.JaroDistance(target);
            var commonPrefixLength = CommonPrefixLength(source, target);

            return jaroDistance + (commonPrefixLength * prefixScale * (1 - jaroDistance));
        }

        private static double CommonPrefixLength(string source, string target)
        {
            var maximumPrefixLength = 4;
            var commonPrefixLength = 0;
            if (source.Length <= 4 || target.Length <= 4) { maximumPrefixLength = Math.Min(source.Length, target.Length); }

            for (var i = 0; i < maximumPrefixLength; i++)
            {
                if (source[i].Equals(target[i])) { commonPrefixLength++; }
                else { return commonPrefixLength; }
            }

            return commonPrefixLength;
        }
    }
}
