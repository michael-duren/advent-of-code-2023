using Shared;
using Shared.Solutions.DayOne;

string testInput = PathInputFactory.Create("One").Test;
string input = PathInputFactory.Create("One").Input;
Console.WriteLine($"Input path: {input}");

List<string> test = Helpers.ReadInput(input);

int result = PartTwo.Solve(test);

Console.WriteLine(result);