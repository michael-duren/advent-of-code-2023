using Shared;
using Shared.Solutions.DaySeven;

string inputPath = PathInputFactory.Create("Seven").Input;

List<string> input = Helpers.ReadInput(inputPath);
long result = PartOne.Solve(input);

Console.WriteLine($"Result: {result}");