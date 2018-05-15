using System.Collections.Generic;
using System.Linq;

namespace StringCompration
{
    public static class Operations
    {
        public static string Capitalize(this string source)
        {
            return source?.ToUpper();
        }

        public static string[] SplitIntoIndividualElements(string source)
        {
            var stringCollection = new string[source.Length];

            for (var i = 0; i < stringCollection.Length; i++)
                stringCollection[i] = source[i].ToString();

            return stringCollection;
        }

        public static string MergeIndividualElementsIntoString(IList<string> source)
        {
            var returnString = "";

            for (var i = 0; i < source.Count(); i++)
                returnString += source.ElementAt(i);
            return returnString;
        }

        public static List<string> ListPrefixes(this string source)
        {
            return source.Select((t, i) => source.Substring(0, i)).ToList();
        }

        public static List<string> ListBiGrams(this string source)
        {
            return ListNGrams(source, 2);
        }

        public static List<string> ListTriGrams(this string source)
        {
            return ListNGrams(source, 3);
        }

        public static List<string> ListNGrams(this string source, int n)
        {
            var nGrams = new List<string>();

            if (n > source.Length)
                return null;
            if (n == source.Length)
            {
                nGrams.Add(source);
                return nGrams;
            }
            for (var i = 0; i < source.Length - n; i++)
                nGrams.Add(source.Substring(i, n));

            return nGrams;
        }
    }
}
