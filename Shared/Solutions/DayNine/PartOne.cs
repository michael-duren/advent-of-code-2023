namespace Shared.Solutions.DayNine
{
    public static class PartOne
    {
        public static long Solve(List<string> lines)
        {
            List<List<int>> parsedLines = ParseInput(lines);

            long acc = 0;
            foreach (var line in parsedLines)
                acc += PredictNextNumber(line);

            return acc;
        }


        public static int PredictNextNumber(List<int> line)
        {
            if (line.All(n => n == 0))
            {
                return 0;
            }

            List<int> newLine = new();
            for (int i = 0; i < line.Count - 1; i++)
            {
                int newNum = line[i + 1] - line[i];
                newLine.Add(newNum);
            }

            int last = PredictNextNumber(newLine);

            return line[^1] + last;
        }

        public static List<List<int>> ParseInput(List<string> lines)
        {
            List<List<int>> intLines = lines
                .Select(l => l.Split(" "))
                .Select(l => l.Select(int.Parse).ToList())
                .ToList();


            return intLines;
        }
    }
}