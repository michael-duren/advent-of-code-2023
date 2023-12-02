using System.Text.RegularExpressions;

namespace Shared.Solutions.DayOne;

/*
 * DOES NOT WORK
 * Can't figure out why
 */
public abstract class PartTwoTryTwo
{
    public static int Solve(List<string> lines)
    {
        return lines.Select(line =>
                {
                    Regex rx = new(@"one|two|three|four|five|six|seven|eight|nine|\d");
                    var matches = rx.Matches(line).Select(m => GetNumFromWord(m.ToString())).ToArray();
                    var result = int.TryParse($"{matches.First()}{matches.Last()}", out var a);
                    return result ? a : 0;
                }
            )
            .Sum();
    }

    private static string GetNumFromWord(string word)
    {
        return word switch
        {
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => word
        };
    }
}