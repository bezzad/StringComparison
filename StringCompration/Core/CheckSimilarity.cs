using System;
using System.Collections.Generic;
using System.Linq;
using StringCompration.Core.Enums;

namespace StringCompration.Core
{
    public static partial class ComparisonMetrics
    {
        public static bool IsSimilar(this string source, string target, StringComparisonTolerance tolerance, params StringComparisonOptions[] options)
        {
            var diff = DiffPercent(source, target, options);

            switch (tolerance)
            {
                case StringComparisonTolerance.Strong:
                    return diff < 0.25;
                case StringComparisonTolerance.Normal:
                    return diff < 0.5;
                case StringComparisonTolerance.Weak:
                    return diff < 0.75;
                default:
                    return false;
            }
        }

        public static double DiffPercent(this string source, string target, params StringComparisonOptions[] options)
        {
            var comparisonResults = new List<double>();

            if (!options.Contains(StringComparisonOptions.CaseSensitive))
            {
                source = source.Capitalize();
                target = target.Capitalize();
            }

            // Min: 0    Max: source.Length = target.Length
            if (options.Contains(StringComparisonOptions.UseHammingDistance))
            {
                if (source.Length == target.Length)
                {
                    comparisonResults.Add(source.HammingDistance(target) / target.Length);
                }
            }

            // Min: 0    Max: 1
            if (options.Contains(StringComparisonOptions.UseJaccardDistance))
            {
                comparisonResults.Add(source.JaccardDistance(target));
            }

            // Min: 0    Max: 1
            if (options.Contains(StringComparisonOptions.UseJaroDistance))
            {
                comparisonResults.Add(source.JaroDistance(target));
            }

            // Min: 0    Max: 1
            if (options.Contains(StringComparisonOptions.UseJaroWinklerDistance))
            {
                comparisonResults.Add(source.JaroWinklerDistance(target));
            }

            // Min: 0    Max: LevenshteinDistanceUpperBounds - LevenshteinDistanceLowerBounds
            // Min: LevenshteinDistanceLowerBounds    Max: LevenshteinDistanceUpperBounds
            if (options.Contains(StringComparisonOptions.UseNormalizedLevenshteinDistance))
            {
                comparisonResults.Add(Convert.ToDouble(source.NormalizedLevenshteinDistance(target)) / Convert.ToDouble((Math.Max(source.Length, target.Length) - source.LevenshteinDistanceLowerBounds(target))));
            }
            else if (options.Contains(StringComparisonOptions.UseLevenshteinDistance))
            {
                comparisonResults.Add(1 - source.LevenshteinDistancePercentage(target));
            }

            if (options.Contains(StringComparisonOptions.UseLongestCommonSubsequence))
            {
                comparisonResults.Add(1 - Convert.ToDouble((source.LongestCommonSubsequence(target).Length) / Convert.ToDouble(Math.Min(source.Length, target.Length))));
            }

            if (options.Contains(StringComparisonOptions.UseLongestCommonSubstring))
            {
                comparisonResults.Add(1 - Convert.ToDouble((source.LongestCommonSubstring(target).Length) / Convert.ToDouble(Math.Min(source.Length, target.Length))));
            }

            // Min: 0    Max: 1
            if (options.Contains(StringComparisonOptions.UseSorensenDiceDistance))
            {
                comparisonResults.Add(source.SorensenDiceDistance(target));
            }

            // Min: 0    Max: 1
            if (options.Contains(StringComparisonOptions.UseOverlapCoefficient))
            {
                comparisonResults.Add(1 - source.OverlapCoefficient(target));
            }

            // Min: 0    Max: 1
            if (options.Contains(StringComparisonOptions.UseRatcliffObershelpSimilarity))
            {
                comparisonResults.Add(1 - source.RatcliffObershelpSimilarity(target));
            }

            return comparisonResults.Average();
        }

        public static double Similarity(this string source, string target, params StringComparisonOptions[] options)
        {
            return 1 - DiffPercent(source, target, options);
        }
    }
}
