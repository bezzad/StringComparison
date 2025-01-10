namespace StringComparison;

public static partial class ComparisonMetrics
{
    public static double HammingDistance(this string source, string target)
    {
        if (source.Length != target.Length)
        {
            // padding smaller string with spaces
            if (source.Length < target.Length)
                source = source.PadRight(target.Length);
            else
                target = target.PadRight(source.Length);
        }

        return source.Where((t, i) => !t.Equals(target[i])).Count();
    }
}