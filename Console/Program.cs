using Shared;
using Shared.Solutions.DayFive;

string inputPath = PathInputFactory.Create("Five").Test;

List<string> input = Helpers.ReadInput(inputPath);
int result = PartOne.Solve(input);

Console.WriteLine($"Result: {result}");
