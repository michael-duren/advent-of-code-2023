using System.Text.RegularExpressions;

namespace Shared.Solutions.DayTwo;

public static partial class DayTwo
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
            Regex rx = Digits();
            foreach (string c in colorSplit)
            {
                if (c.Contains("red"))
                {
                    TotalRed += int.Parse(rx.Match(c).ToString());
                }
                else if (c.Contains("green"))
                {
                    TotalGreen += int.Parse(rx.Match(c).ToString());
                }
                else if (c.Contains("blue"))
                {
                    TotalBlue += int.Parse(rx.Match(c).ToString());
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
            Regex rx = Digits();
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

    private class RoundAlt
    {
        public void UpdateMin(string colors)
        {
            string[] colorSplit = colors.Split(",");
            foreach (string c in colorSplit)
            {
                if (c.Contains("red"))
                {
                    MinRed = GetMin(c, MinRed);
                }
                else if (c.Contains("green"))
                {
                    MinGreen = GetMin(c, MinGreen);
                }
                else if (c.Contains("blue"))
                {
                    MinBlue = GetMin(c, MinBlue);
                }
            }
        }

        public int ReturnPower()
        {
            return MinRed * MinGreen * MinBlue;
        }


        private int MinRed { get; set; }
        private int MinGreen { get; set; }
        private int MinBlue { get; set; }
    }

    public static int SolvePartTwo(List<string> lines)
    {
        int totalPower = 0;

        lines.ForEach(line =>
        {
            string[] split = line.Split(":");
            string[] colorRounds = split[1].Split(";");

            RoundAlt round = new();
            foreach (var colorRound in colorRounds)
            {
                round.UpdateMin(colorRound);
            }

            totalPower += round.ReturnPower();
        });

        return totalPower;
    }

    private static int GetMin(string colorString, int curr)
    {
        Regex rx = Digits();
        int colorCount = int.Parse(rx.Match(colorString).ToString());
        return colorCount > curr ? colorCount : curr;
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex Digits();
}