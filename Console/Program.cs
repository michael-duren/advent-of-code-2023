using Shared;
using Shared.Solutions.DayFour;

string inputPath = PathInputFactory.Create("Four").Input;

List<string> input = Helpers.ReadInput(inputPath);
int result = PartTwo.Solve(input);

Console.WriteLine($"Result: {result}");
