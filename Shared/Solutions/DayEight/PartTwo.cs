namespace Shared.Solutions.DayEight;

public static class PartTwo
{
    public class Map
    {
        public required int[] Directions { get; init; }
        public Dictionary<string, string[]> Nodes { get; set; } = null!;
    }


    public static int Solve(List<string> lines)
    {
        Map map = ParseInput(lines);

        List<string> currNodes = map.Nodes.Keys.Where(k => k.EndsWith('A')).ToList();
        int moves = 0;

        while (!(currNodes.All(n => n.EndsWith('Z'))))
        {
            foreach (var direction in map.Directions)
            {
                moves++;
                for (int j = 0; j < currNodes.Count; j++)
                {
                    string[] result = map.Nodes.TryGetValue(currNodes[j], out string[]? dir)
                        ? dir
                        : throw new Exception("Issue getting node value from dict");
                    var nextItem = result[direction];
                    currNodes[j] = nextItem;
                }
            }
        }

        return moves;
    }

    private static Map ParseInput(List<string> lines)
    {
        Map map = new()
        {
            Directions = lines[0].Trim().ToCharArray().Select(x => x == 'L' ? 0 : 1).ToArray()
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