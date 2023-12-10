namespace Shared.Solutions.DayNine
{
    public static class PartOne
    {
        public static long Solve(List<string> lines)
        {
            List<List<int>> parsedLines = ParseInput(lines);

            long acc = 0;
            foreach (var line in parsedLines)
                acc += PredictNextNumber(line, new List<List<int>>());

            return acc;
        }


        public static int PredictNextNumber(List<int> line, List<List<int>> lines)
        {
            if (line.All(n => n == 0))
            {
                return 0;
            }

            lines.Add(line);

            List<int> newLine = new();
            for (int i = 0; i < line.Count - 1; i++)
            {
                int newNum = line[i + 1] - line[i];
                newLine.Add(newNum);
            }

            int last = PredictNextNumber(newLine, lines);

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