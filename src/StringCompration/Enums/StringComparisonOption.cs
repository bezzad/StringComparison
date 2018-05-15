using System;

namespace StringCompration.Enums
{
    [Flags]
    public enum StringComparisonOption
    {
        UseHammingDistance = 1,
        UseJaccardDistance = 2,
        UseJaroDistance = 4,
        UseJaroWinklerDistance = 8,
        UseLevenshteinDistance = 16,
        UseLongestCommonSubsequence = 32,
        UseLongestCommonSubstring = 64,
        UseNormalizedLevenshteinDistance = 128,
        UseOverlapCoefficient = 256,
        UseRatcliffObershelpSimilarity = 512,
        UseSorensenDiceDistance = 1024,
        UseTanimotoCoefficient = 2048,
        CaseSensitive = 4096
    }
}