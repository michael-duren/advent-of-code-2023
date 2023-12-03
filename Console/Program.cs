using Shared;
using Shared.Solutions.DayThree;

string input = PathInputFactory.Create("Three").Input;
Console.WriteLine($"Input path: {input}");

List<string> test = Helpers.ReadInput(input);

int result = PartOne.Solve(test);

Console.WriteLine(result);