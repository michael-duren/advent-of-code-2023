using Shared;
using static Shared.Solutions.DayEight.PartOne;

string inputPath = PathInputFactory.Create("Eight").Input;

List<string> input = Helpers.ReadInput(inputPath);
long result = Solve(input);

Console.WriteLine($"Result: {result}");