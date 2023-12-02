using System.Globalization;
using System.Text.RegularExpressions;

namespace Shared.Solutions.DayOne
{
    public static class PartOne
    {
        public static int Solve(List<string> lines)
        {
            return lines.Select(line =>
                    {
                        char[] numArray = line.ToCharArray().Where(char.IsDigit).ToArray();
                        return int.Parse($"{numArray[0]}{numArray.Last()}");
                    }
                )
                .Sum();
        }
    }
}