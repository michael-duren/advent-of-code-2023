using Shared;
using static Shared.Solutions.DayNine.PartOne;

string inputPath = PathInputFactory.Create("Nine").Input;

List<string> input = Helpers.ReadInput(inputPath);
long result = Solve(input);

Console.WriteLine($"Result: {result}");