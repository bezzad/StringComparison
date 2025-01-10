﻿using System.Text;

namespace StringComparison;

public static partial class ComparisonMetrics
{
    public static string LongestCommonSubstring(this string source, string target)
    {
        if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target)) return null;

        var L = new int[source.Length, target.Length];
        var maximumLength = 0;
        var lastSubsBegin = 0;
        var stringBuilder = new StringBuilder();

        for (var i = 0; i < source.Length; i++)
        for (var j = 0; j < target.Length; j++)
            if (source[i] != target[j])
            {
                L[i, j] = 0;
            }
            else
            {
                if (i == 0 || j == 0)
                    L[i, j] = 1;
                else
                    L[i, j] = 1 + L[i - 1, j - 1];

                if (L[i, j] > maximumLength)
                {
                    maximumLength = L[i, j];
                    var thisSubsBegin = i - L[i, j] + 1;
                    if (lastSubsBegin == thisSubsBegin)
                    {
                        //if the current LCS is the same as the last time this block ran
                        stringBuilder.Append(source[i]);
                    }
                    else //this block resets the string builder if a different LCS is found
                    {
                        lastSubsBegin = thisSubsBegin;
                        stringBuilder.Length = 0; //clear it
                        stringBuilder.Append(source.Substring(lastSubsBegin, i + 1 - lastSubsBegin));
                    }
                }
            }

        return stringBuilder.ToString();
    }
}