using Shared;

public partial class Program
{
    private static IEnumerable<string> ReadInput(string path)
    {
        IEnumerable<string>? file = File.ReadLines(path) ?? throw new FileNotFoundException("File not found", path);
        return file;
    }
    public static PathInput[] Paths { get; set; } = {  
        new PathInput{ Day = "DayOne", Input = "../PuzzleInput/input.txt", Test = "../PuzzleInput/Day-1/test" },
        new PathInput{ Day = "DayOne", Input = "../PuzzleInput/input.txt", Test = "../PuzzleInput/Day-1/test" }
    };
}
