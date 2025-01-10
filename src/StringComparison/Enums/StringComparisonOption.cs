namespace StringComparison.Enums;

[Flags]
public enum StringComparisonOption
{
    CaseSensitive = 1,
    Normalized = 2,
    UseHammingDistance = 4,
    UseJaccardDistance = 8,
    UseJaroDistance = 16,
    UseJaroWinklerDistance = 32,
    UseLevenshteinDistance = 64,
    UseLongestCommonSubsequence = 128,
    UseLongestCommonSubstring = 256,
    UseNormalizedLevenshteinDistance = 512,
    UseOverlapCoefficient = 1024,
    UseRatcliffObershelpSimilarity = 2048,
    UseSorensenDiceDistance = 4096,
    UseTanimotoCoefficient = 8192
}