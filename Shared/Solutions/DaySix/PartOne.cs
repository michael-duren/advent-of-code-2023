namespace Shared.Solutions.DaySix
{

    public class PartOne
    {
        private struct Record
        {
            public int Time { get; set; }
            public int Distance { get; set; }
        }
        public static int Solve(List<string> input)
        {
            return 0;
        }

        private static List<Record> ParseInput(List<string> lines)
        {
            List<int> times = lines[0]
                .Split(' ')
                .Select(x => int.TryParse(x, out var result) ? result : 0)
                .Where(x => x != 0)
                .ToList();

            List<int> distances = lines[1]
                .Split(' ')
                .Select(x => int.TryParse(x, out var result) ? result : 0)
                .Where(x => x != 0)
                .ToList();

            List<Record> records = new List<Record>();
            for (int i = 0; i < times.Count; i++)
            {
                records.Add(new Record
                {
                    Time = times[i],
                    Distance = distances[i]
                });
            }
            return records;
        }
    }

}
