using Shared;
using static Shared.Solutions.DaySeven.PartTwo;

string inputPath = PathInputFactory.Create("Seven").Input;

List<string> input = Helpers.ReadInput(inputPath);
long result = Solve(input);

Console.WriteLine($"Result: {result}");