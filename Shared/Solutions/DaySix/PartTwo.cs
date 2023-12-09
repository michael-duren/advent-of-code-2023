namespace Shared.Solutions.DaySix
{
    public static class PartTwo
    {
        private struct Record
        {
            public long Time { get; set; }
            public long Distance { get; set; }
        }

        public static long Solve(List<string> input)
        {
            Record record = ParseInput(input);

            long waysToBeatForThisRecord = 0;

            for (long i = 1; i < record.Time; i++)
            {
                long speed = i;
                long remainingTime =
                    record.Time - speed; // decrement the time for the time it took us to get to the speed
                long distanceTraveled = speed * remainingTime;

                if (distanceTraveled > record.Distance)
                {
                    waysToBeatForThisRecord++;
                }
            }

            return waysToBeatForThisRecord;
        }

        private static Record ParseInput(List<string> lines)
        {
            string time = lines[0]
                .Split(' ')
                .Select(x => int.TryParse(x, out int result) ? result : 0)
                .Where(x => x != 0)
                .Select(s => s.ToString())
                .Aggregate((curr, next) => $"{curr}{next}");

            string distance = lines[1]
                .Split(' ')
                .Select(x => int.TryParse(x, out int result) ? result : 0)
                .Where(x => x != 0)
                .Select(s => s.ToString())
                .Aggregate((curr, next) => $"{curr}{next}");

            Record record = new()
            {
                Time = long.TryParse(time, out long timeResult) ? timeResult : 0,
                Distance = long.TryParse(distance, out long distanceResult) ? distanceResult : 0
            };

            return record;
        }
    }
}
