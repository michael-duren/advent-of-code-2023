using Shared;
using Shared.Solutions.DayTwo;

string input = PathInputFactory.Create("Two").Input;
Console.WriteLine($"Input path: {input}");

List<string> test = Helpers.ReadInput(input);

int result = DayTwo.SolvePartTwo(test);

Console.WriteLine(result);
