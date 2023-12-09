using Shared;
using Shared.Solutions.DaySix;

string inputPath = PathInputFactory.Create("Six").Input;

List<string> input = Helpers.ReadInput(inputPath);
long result = PartTwo.Solve(input);

Console.WriteLine($"Result: {result}");