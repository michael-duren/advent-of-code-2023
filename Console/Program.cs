using Shared;
using static Shared.Solutions.DayNine.PartTwo;

string inputPath = PathInputFactory.Create("Nine").Input;

List<string> input = Helpers.ReadInput(inputPath);
long result = Solve(input);

Console.WriteLine($"Result: {result}");
