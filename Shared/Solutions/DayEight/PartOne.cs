namespace Shared.Solutions.DayEight
{
    public static class PartOne
    {
        public class Map
        {
            public required int[] Directions { get; set; }
            public Dictionary<string, string[]> Nodes { get; set; } = null!;
        }


        public static int Solve(List<string> lines)
        {
            Map map = ParseInput(lines);

            string currentNode = "AAA";
            int moves = 0;

            while (currentNode != "ZZZ")
            {
                for (int i = 0; i < map.Directions.Length; i++)
                {
                    moves++;
                    int nextMoveIndex = map.Directions[i];
                    string[] result = map.Nodes.TryGetValue(currentNode, out string[]? directions)
                        ? directions
                        : throw new Exception("Issue Parsing nodes");
                    currentNode = result[nextMoveIndex];
                }
            }

            return moves;
        }

        public static Map ParseInput(List<string> lines)
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
                nodes.Add(key, new string[]
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
}