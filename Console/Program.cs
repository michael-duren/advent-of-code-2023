using Shared;
using Shared.Solutions.DayFive;

string inputPath = PathInputFactory.Create("Five").Input;

List<string> input = Helpers.ReadInput(inputPath);
long result = PartTwo.Solve(input);

Console.WriteLine($"Result: {result}");