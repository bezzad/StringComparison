using StringComparison.Enums;
using Xunit.Abstractions;

namespace StringComparison.Test;

public class Tests(ITestOutputHelper output)
{
    [Theory]
    [InlineData("قلعه حیوانات", "قلعه حیوانات")]
    [InlineData("قلعه حیوانات", "قلعه ای برای حیوانات")]
    [InlineData("قلعه حیوانات", "قلعه‌ی حیوانات")]
    [InlineData("قلعه حیوانات", "قلعه حیوانات (خلاصه کتاب)")]
    [InlineData("قلعه حیوانات", "مزرعه حیوانات")]
    [InlineData("قلعه حیوانات", "کلینیک حیوانات")]
    [InlineData("قلعه حیوانات", "خانه حیوانات")]
    [InlineData("من قبل از تو", "من پیش از تو")]
    [InlineData("ماهی طلایی", "ماهی سیاه")]
    [InlineData("او من", "من او")]
    [InlineData("آتشین دیوار", "دیوار آتشین")]
    [InlineData("ملت عشق", "عشق")]
    [InlineData("دخیل عشق", "انسان و عشق")]
    [InlineData("مامان و بابای سیاه پلنگ صورتی", "مامبای سیاه و عشق صورتی")]
    [InlineData("باهم او من", "من او باهم")]
    [InlineData("تحلیلی بر پوسترسازی دفاع مقدس و دو جنگ جهانی- بخش دوم",
        "تحلیلی بر پوسترسازی دفاع مقدس و دو جنگ جهانی- بخش اول")]
    [InlineData("کیمیاگران", "کیمیاگر")]
    [InlineData("کیمیاگری", "کیمیاگر")]
    [InlineData(" کیمیاگر ", "کیمیاگر")]
    [InlineData("شبیه‌سازی عشق", "مدل‌سازی عشق")]
    [InlineData("تار", "راز")]
    [InlineData("قاز", "راز")]
    [InlineData("قار", "تار")]
    [InlineData("ماهنامه", "روزنامه")]
    public void UseAllAlgorithms(string source, string target)
    {
        output.WriteLine($"  {source}  !==!  {target}");
        output.WriteLine("--------------------");

        ExecuteAll(source, target);
    }

    private void ExecuteAll(string source, string target)
    {
        foreach (var option in Enum.GetValues<StringComparisonOption>())
        {
            if (option is StringComparisonOption.CaseSensitive or 
                StringComparisonOption.Normalized)
                continue;

            var sOpt = option | StringComparisonOption.Normalized;
            var tolerance = 1;
            while (tolerance <= 3)
            {
                var isSimilar = source.IsSimilar(target, (StringComparisonTolerance)tolerance, sOpt);
                if (isSimilar)
                    break;
                tolerance++;
            }

            var toleranceName = tolerance < 4 ? ((StringComparisonTolerance)tolerance).ToString() : "!";
            Assert.True((tolerance < 4) == source.IsSimilar(target, StringComparisonTolerance.Weak, sOpt));
            output.WriteLine($"{option.ToString()} Similarity: % {source.Similarity(target, sOpt) * 100} {toleranceName}");
            output.WriteLine($"{option.ToString()} Distance: " + source.DiffPercent(target, sOpt));
            output.WriteLine("");
        }
    }

    [Theory]
    [InlineData("Alex Taremi", "Taromi, Alex", true)]
    [InlineData("Mohammad Taremi", "Taromi, Alex", false)]
    public void TestIsSimilarUseOverlapAndJaro(string source, string target, bool expected)
    {
        // act
        var result = source.IsSimilar(target, StringComparisonTolerance.Strong,
            StringComparisonOption.UseJaccardDistance);
        
        Assert.Equal(expected, result);
        
        ExecuteAll(source, target);
    }
}