namespace Shared.Solutions.DayEight;

public static class PartTwo
{
    public class Map
    {
        public required List<int> Directions { get; init; }
        public Dictionary<string, string[]> Nodes { get; set; } = null!;
    }


    public static long Solve(List<string> lines)
    {
        Map map = ParseInput(lines);

        List<string> positions = map.Nodes.Keys.Where(k => k.EndsWith('A')).ToList();
        List<List<int>> cycles = new();

        foreach (string position in positions)
        {
            List<int> cycle = new();
            string? current = position;
            List<int> currentSteps = map.Directions;
            int stepCount = 0;
            string? firstZ = null;

            while (true)
            {
                while (stepCount == 0 || !current.EndsWith('Z'))
                {
                    stepCount++;
                    current = map.Nodes[current][currentSteps[0]];
                    int firstEl = currentSteps[0];
                    currentSteps.RemoveAt(0);
                    currentSteps.Add(firstEl);
                }

                cycle.Add(stepCount);

                if (firstZ is null)
                {
                    firstZ = current;
                    stepCount = 0;
                }
                else if (current == firstZ)
                {
                    break;
                }
            }

            cycles.Add(cycle);
        }

        List<int> nums = cycles.Select(c => c[0]).ToList();
        long lcm = nums[0];
        for (int i = 1; i < nums.Count; i++)
        {
            lcm = Lcm(lcm, nums[i]);
        }

        return lcm;
    }


    private static long Gcd(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private static long Lcm(long a, long b)
    {
        return a / Gcd(a, b) * b; // Ensuring division happens first to avoid overflow
    }

    private static Map ParseInput(List<string> lines)
    {
        Map map = new()
        {
            Directions = lines[0].Trim().ToCharArray().Select(x => x == 'L' ? 0 : 1).ToList()
        };

        Dictionary<string, string[]> nodes = new();

        foreach (string line in lines)
        {
            if (!(line.Contains('='))) continue;

            string[] split = line.Split('=');
            string key = split[0].Trim();
            string[] secondSplit = split[1].Split(",");
            nodes.Add(key, new[]
                {
                    secondSplit[0].Replace('(', ' ').Trim(),
                    secondSplit[1].Replace(')', ' ').Trim()
                }
            );
        }

        map.Nodes = nodes;

        return map;
    }
}
