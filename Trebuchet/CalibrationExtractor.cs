using System.Text.RegularExpressions;

namespace Trebuchet;

public static class CalibrationExtractor
{
    private static Dictionary<string, string> digitDictionary = new()
    {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" }
    };

    public static int CalculateCalibration(IEnumerable<string> map)
    {
        return map.Sum(m =>
        {
            var firstDigit = m.First(char.IsDigit);
            var lastDigit = m.Last(char.IsDigit);
            return int.Parse($"{firstDigit}{lastDigit}");
        });
    }

    public static int CalculateCalibrationWithStringDigits(IEnumerable<string> map)
    {
        return map.Sum(m =>
        {
            var sortedKeys = digitDictionary.Keys.OrderByDescending(k => k.Length);
            var pattern = $"(\\d|{string.Join("|", sortedKeys)})";
            var regexLeftToRight = new Regex(pattern);
            var regexRightToLeft = new Regex(pattern, RegexOptions.RightToLeft);

            var firstMatch = regexLeftToRight.Match(m).Value;
            var lastMatch = regexRightToLeft.Match(m).Value;

            var firstDigit = digitDictionary.ContainsKey(firstMatch) ? digitDictionary[firstMatch] : firstMatch;
            var lastDigit = digitDictionary.ContainsKey(lastMatch) ? digitDictionary[lastMatch] : lastMatch;

            return int.Parse($"{firstDigit}{lastDigit}");
        });
    }
}