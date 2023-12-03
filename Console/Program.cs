using Shared;
using Shared.Solutions.DayThree;

string inputPath = PathInputFactory.Create("Three").Input;

List<string> input = Helpers.ReadInput(inputPath);
int result = PartTwo.Solve(input);

Console.WriteLine($"Result: {result}");