using Shared;
using Shared.Solutions.DayFive;

string inputPath = PathInputFactory.Create("Five").Input;

List<string> input = Helpers.ReadInput(inputPath);
ulong result = PartOne.Solve(input);

Console.WriteLine($"Result: {result}");
