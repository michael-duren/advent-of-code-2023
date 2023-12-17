namespace Shared
{
    public struct PathInput
    {
        public string Input { get; set; }
        public string Test { get; set; }
        public string TestTwo { get; set; }
        public string TestThree { get; set; }
    }

    public static class PathInputFactory
    {
        public static PathInput Create(string day, string part = "One")
        {
            return new PathInput
            {
                Input = $"/Users/michaelduren/Code/advent-of-code-2023/PuzzleInput/Day{day}/Part{part}/input",
                Test = $"/Users/michaelduren/Code/advent-of-code-2023/PuzzleInput/Day{day}/Part{part}/test",
                TestTwo = $"/Users/michaelduren/Code/advent-of-code-2023/PuzzleInput/Day{day}/Part{part}/test_two",
                TestThree = $"/Users/michaelduren/Code/advent-of-code-2023/PuzzleInput/Day{day}/Part{part}/test_three",

            };
        }
    }
}
