namespace Shared
{
    public struct PathInput
    {
        public string Input { get; set; }
        public string Test { get; set; }
    }

    public static class PathInputFactory
    {
        public static PathInput Create(string day, string part = "One")
        {
            return new PathInput
            {
                Input = $"/Users/michaelduren/Code/advent-of-code-2023/PuzzleInput/Day{day}/Part{part}/input",
                Test = $"/Users/michaelduren/Code/advent-of-code-2023/PuzzleInput/Day{day}/Part{part}/test"
            };
        }
    }
}