using Shared;
using static Shared.Solutions.DayTen.PartTwo;

string inputPath = PathInputFactory.Create("Ten").Input;
//
List<string> input = Helpers.ReadInput(inputPath);
long result = Solve(input);

Console.WriteLine($"Result: {result}");