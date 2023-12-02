using System.Text.RegularExpressions;

namespace Shared.Solutions.DayOne;

public abstract partial class PartTwo
{
    public static int Solve(List<string> lines)
    {
        Regex rx = MyRegex();
        return lines.Select(line =>
                {
                    var matches = rx.Matches(ReplaceWordNumbers(line)).Select(m => m.ToString()).ToArray();
                    var result = int.TryParse($"{matches[0]}{matches[^1]}", out var a);
                    return result ? a : 0;
                }
            )
            .Sum();
    }

    private static string ReplaceWordNumbers(string line)
    {
        line = line.Replace("one", "one1one");
        line = line.Replace("two", "two2two");
        line = line.Replace("three", "three3three");
        line = line.Replace("four", "four4four");
        line = line.Replace("five", "five5five");
        line = line.Replace("six", "six6six");
        line = line.Replace("seven", "seven7seven");
        line = line.Replace("eight", "eight8eight");
        line = line.Replace("nine", "nine9nine");
        return line;
    }

    [GeneratedRegex(@"\d")]
    private static partial Regex MyRegex();
}