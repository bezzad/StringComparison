﻿using System;
using System.Linq;

namespace StringCompration.Core
{
    public static partial class ComparisonMetrics
    {
        public static double RatcliffObershelpSimilarity(this string source, string target)
        {
            return (2 * Convert.ToDouble(source.Intersect(target).Count())) / (Convert.ToDouble(source.Length + target.Length));
        }
    }
}
