using System;

namespace StringComparison
{
    public static partial class ComparisonMetrics
    {
        public static double JaroWinklerDistance(this string source, string target)
        {
            var jaroDistance = source.JaroDistance(target);
            var commonPrefixLength = CommonPrefixLength(source, target);

            return jaroDistance + commonPrefixLength * 0.1 * (1 - jaroDistance);
        }

        public static double JaroWinklerDistanceWithPrefixScale(string source, string target, double prefixScale)
        {
            if (prefixScale > 0.25) prefixScale = 0.25;
            else if (prefixScale < 0) prefixScale = 0;

            var jaroDistance = source.JaroDistance(target);
            var commonPrefixLength = CommonPrefixLength(source, target);

            return jaroDistance + commonPrefixLength * prefixScale * (1 - jaroDistance);
        }

        private static double CommonPrefixLength(string source, string target)
        {
            var maximumPrefixLength = 4;
            var commonPrefixLength = 0;
            if (source.Length <= 4 || target.Length <= 4) maximumPrefixLength = Math.Min(source.Length, target.Length);

            for (var i = 0; i < maximumPrefixLength; i++)
                if (source[i].Equals(target[i])) commonPrefixLength++;
                else return commonPrefixLength;

            return commonPrefixLength;
        }
    }
}
