namespace Shared.Solutions.DaySix
{
    public static class PartOne
    {
        private struct Record
        {
            public int Time { get; set; }
            public int Distance { get; set; }
        }

        public static int Solve(List<string> input)
        {
            List<Record> records = ParseInput(input);

            int waysToBeatRecord = 0;

            foreach (Record record in records)
            {
                int waysToBeatForThisRecord = 0;

                for (int i = 1; i < record.Time - 1; i++)
                {
                    int speed = i;
                    int remainingTime =
                        record.Time - speed; // decrement the time for the time it took us to get to the speed
                    int distanceTraveled = speed * remainingTime;

                    if (distanceTraveled > record.Distance)
                    {
                        waysToBeatForThisRecord++;
                    }
                }

                if (waysToBeatForThisRecord == 0)
                {
                    waysToBeatRecord += waysToBeatForThisRecord;
                    continue;
                }

                waysToBeatRecord *= waysToBeatForThisRecord;
            }

            return waysToBeatRecord;
        }

        private static List<Record> ParseInput(List<string> lines)
        {
            List<int> times = lines[0]
                .Split(' ')
                .Select(x => int.TryParse(x, out int result) ? result : 0)
                .Where(x => x != 0)
                .ToList();

            List<int> distances = lines[1]
                .Split(' ')
                .Select(x => int.TryParse(x, out int result) ? result : 0)
                .Where(x => x != 0)
                .ToList();

            List<Record> records = new();
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