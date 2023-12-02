namespace Shared
{
    public struct PathInput
    {
        public string Day { get; set; }
        public string Input { get; set; }
        public string Test { get; set; }
    }

    public static class PathInputFactory
    {
        public static PathInput Create(string day, string part = "")
        {
            if (string.IsNullOrEmpty(part)) part = day;
            return new PathInput
            {
                Day = day,
                Input = $"/Users/michaelduren/Code/advent-of-code-2023/PuzzleInput/Day{day}/Part{part}/input",
                Test = $"/Users/michaelduren/Code/advent-of-code-2023/PuzzleInput/Day{day}/Part{part}/test"
            };
        }
    }
}