namespace Shared.Solutions.DayFour;

public static class PartOne
{
    public record Round
    {
        public List<int> WinningNumbers { get; init; } = null!;
        public List<int> YourNumbers { get; init; } = null!;
    }

    public static int ResolvePoints(int matches)
    {
        switch (matches)
        {
            case 1:
                return 1;
            case 0:
                return 0;
        }

        int totalPoints = 0;
        for (int i = 1; i <= matches; i++)
        {
            if (i == 1)
            {
                totalPoints += 1;
                continue;
            }

            totalPoints = totalPoints * 2;
        }

        return totalPoints;
    }

    public static Round ParseInput(string line)
    {
        string[] firstSplit = line.Split(":");
        string[] secondSplit = firstSplit[1].Split("|");

        Round round = new()
        {
            WinningNumbers = secondSplit[0].Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList(),
            YourNumbers = secondSplit[1].Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList()
        };
        return round;
    }

    public static int Solve(List<string> input)
    {
        int totalPoints = 0;

        foreach (var line in input)
        {
            Round round = ParseInput(line);
            int totalMatches = round.YourNumbers.Count(number => round.WinningNumbers.Contains(number));
            totalPoints += ResolvePoints(totalMatches);
        }

        return totalPoints;
    }
}