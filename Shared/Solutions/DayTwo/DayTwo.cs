using System.Text.RegularExpressions;

namespace Shared.Solutions.DayTwo;

public static class DayTwo
{
    private class Round
    {
        private readonly int _allowedRed;
        private readonly int _allowedGreen;
        private readonly int _allowedBlue;

        public Round(string colors)
        {
            _allowedRed = 12;
            _allowedGreen = 13;
            _allowedBlue = 14;

            string[] colorSplit = colors.Split(",");
            foreach (string c in colorSplit)
            {
                if (c.Contains("red"))
                {
                    TotalRed += int.Parse(c.Replace("red", "").Trim());
                }
                else if (c.Contains("green"))
                {
                    TotalGreen += int.Parse(c.Replace("green", "").Trim());
                }
                else if (c.Contains("blue"))
                {
                    TotalBlue += int.Parse(c.Replace("blue", "").Trim());
                }
            }
        }

        private int TotalRed { get; }
        private int TotalGreen { get; }
        private int TotalBlue { get; }

        public bool RoundIsValid()
        {
            return TotalRed <= _allowedRed && TotalGreen <= _allowedGreen && TotalBlue <= _allowedBlue;
        }
    }

    public static int SolvePartOne(List<string> lines)
    {
        int possibleGames = 0;

        lines.ForEach((line) =>
        {
            string[] split = line.Split(":");
            (string roundNumber, string[] colorRounds) = (split[0], split[1].Split(";"));

            bool isPossible = true;
            Regex rx = new(@"\d+");
            int roundNumberParsed = int.Parse(rx.Match(roundNumber).ToString());

            foreach (var colorRound in colorRounds)
            {
                Round round = new(colorRound);

                if (!round.RoundIsValid())
                {
                    isPossible = false;
                    break;
                }
            }

            possibleGames += isPossible ? roundNumberParsed : 0;
        });
        return possibleGames;
    }

    public static int SolvePartTwo(List<string> lines)
    {
        return 0;
    }
}