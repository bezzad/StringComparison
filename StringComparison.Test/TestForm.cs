using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StringCompration.Core;
using StringCompration.Core.Enums;

namespace StringComparison.Test
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            Test("قلعه حیوانات", "قلعه حیوانات");
            Test("قلعه حیوانات", "قلعه ای برای حیوانات");
            Test("قلعه حیوانات", "قلعه‌ی حیوانات");
            Test("قلعه حیوانات", "قلعه حیوانات (خلاصه کتاب)");
            Test("قلعه حیوانات", "مزرعه حیوانات");
            Test("قلعه حیوانات", "کلینیک حیوانات");
            Test("قلعه حیوانات", "خانه حیوانات");
            Test("من قبل از تو", "من پیش از تو");
            Test("ماهی طلایی", "ماهی سیاه");
            Test("او من", "من او");
            Test("آتشین دیوار", "دیوار آتشین");
            Test("ملت عشق", "عشق");
            Test("دخیل عشق", "انسان و عشق");
            Test("مامان و بابای سیاه پلنگ صورتی", "مامبای سیاه و عشق صورتی");
            Test("باهم او من", "من او باهم");
            Test("تحلیلی بر پوسترسازی دفاع مقدس و دو جنگ جهانی- بخش دوم", "تحلیلی بر پوسترسازی دفاع مقدس و دو جنگ جهانی- بخش اول");
            Test("کیمیاگران", "کیمیاگر");
            Test("کیمیاگری", "کیمیاگر");
            Test(" کیمیاگر ", "کیمیاگر");
            Test("شبیه‌سازی عشق", "مدل‌سازی عشق");
            Test("تار", "راز");
            Test("قاز", "راز");
            Test("قار", "تار");
            Test("ماهنامه", "روزنامه");
        }

        public void Test(string source, string target)
        {
            WriteLine("-------------------------------------------------------------");
            WriteLine($"  {source}  !==!  {target}");
            WriteLine("-------------------------------------------------------------");

            var options = StringComparisonOption.UseJaccardDistance | 
                          StringComparisonOption.UseLevenshteinDistance;

            WriteLine("String Comparison: %" + source.Similarity(target, options) * 100);
            WriteLine("Strong compare: " + source.IsSimilar(target, StringComparisonTolerance.Strong, options));
            WriteLine("Normal compare: " + source.IsSimilar(target, StringComparisonTolerance.Normal, options));
            WriteLine("Weak compare: " + source.IsSimilar(target, StringComparisonTolerance.Weak, options));

            WriteLine();
            WriteLine("LevenshteinDistance: " + (1 - source.LevenshteinDistancePercentage(target)));
            WriteLine("JaccardDistance: " + source.JaccardDistance(target));
            if (source.Length == target.Length)
            {
                WriteLine("HammingDistance: " + source.HammingDistance(target) / target.Length);
            }
            WriteLine();
            WriteLine("SorensenDiceDistance: " + source.SorensenDiceDistance(target));
            WriteLine("JaroDistance: " + source.JaroDistance(target));
            WriteLine("LevenshteinDistanceLowerBounds: " + source.LevenshteinDistanceLowerBounds(target));
            WriteLine("LevenshteinDistanceUpperBounds: " + source.LevenshteinDistanceUpperBounds(target));
            WriteLine("NormalizedLevenshteinDistance: " + source.NormalizedLevenshteinDistance(target));
            WriteLine("JaroWinklerDistance: " + source.JaroWinklerDistance(target));
            WriteLine("OverlapCoefficient: " + source.OverlapCoefficient(target));
            WriteLine("RatcliffObershelpSimilarity: " + source.RatcliffObershelpSimilarity(target));
            WriteLine("TanimotoCoefficient: " + source.TanimotoCoefficient(target));
            WriteLine("-------------------------------------------------------------");
            WriteLine();
        }

        private void WriteLine(string text = "\n\r")
        {
            txtOutput.Text += text + Environment.NewLine;
        }
    }
}
