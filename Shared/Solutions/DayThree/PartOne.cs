using System.Text.RegularExpressions;

namespace Shared.Solutions.DayThree;

public static partial class PartOne
{
    private static readonly List<Position> _directions = new()
    {
        new Position { X = 0, Y = -1 }, // Go Up
        new Position { X = 1, Y = 0 }, // Go Right
        new Position { X = 0, Y = 1 }, // Go Down
        new Position { X = -1, Y = 0 }, // Go Left
        new Position { X = 1, Y = -1 }, // Go Diagonal Right
        new Position { X = -1, Y = -1 }, // Go Diagonal Left
        new Position { X = 1, Y = 1 }, // Go Diagonal Bottom Right
        new Position { X = -1, Y = 1 }, // Go Diagonal Bottom Left
    };

    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public struct Result
    {
        public string Numbers { get; set; }
        public bool HasSpecialCharacter { get; set; }
    }

    public static bool NumberContinues(List<string> schematic, Position position)
    {
        var newPosition = position with { X = position.X + 1 };

        // make sure we dont go out of bounds
        if (newPosition.X < 0 || newPosition.X >= schematic[0].Length)
            return false;

        if (newPosition.Y < 0 || newPosition.Y >= schematic.Count)
            return false;

        // if we find a number to the right of us we know that we need to keep track of the numbers
        if (char.IsNumber(schematic[newPosition.Y][newPosition.X]))
            return true;

        return false;
    }

    // If we find a number to the right of us we know that we need to keep track of the numbers
    // if we find a special character i.e. * # + $ we know that this is part of schematic
    public static bool HasSpecialChar(List<string> schematic, Position position)
    {
        Regex rx = SpecialChar();
        for (int i = 0; i < _directions.Count; i++)
        {
            var newPosition = new Position
            {
                X = position.X + _directions[i].X,
                Y = position.Y + _directions[i].Y
            };

            // make sure we dont go out of bounds
            if (newPosition.X < 0 || newPosition.X >= schematic[0].Length)
                continue;

            if (newPosition.Y < 0 || newPosition.Y >= schematic.Count)
                continue;

            // if we find speical char return true
            if (rx.IsMatch(schematic[newPosition.Y][newPosition.X].ToString()))
                return true;
        }

        return false;
    }

    public static int Solve(List<string> lines)
    {
        Stack<int> numbers = new();
        for (int i = 0; i < lines.Count; i++)
        {
            // keep result for iterating through the x axis
            Result result = new() { HasSpecialCharacter = false };
            for (int j = 0; j < lines[i].Length; j++)
            {
                Position position = new() { X = j, Y = i };
                char currentCharacter = lines[position.Y][position.X];
                if (!char.IsDigit(currentCharacter) && result.Numbers is null)
                {
                    continue;
                }

                // check if we are on a number
                if (char.IsDigit(currentCharacter))
                {
                    result.Numbers += currentCharacter;
                }

                // check if there is a neighboring special char, if we already have a special char for this number set then don't need to check again
                if (HasSpecialChar(lines, position) && char.IsDigit(currentCharacter) && !result.HasSpecialCharacter)
                {
                    result.HasSpecialCharacter = true;
                }

                // if there isn't a number that continues then determine if we should push this collection to the numbers list
                if (!NumberContinues(lines, position))
                {
                    if (result.HasSpecialCharacter && !string.IsNullOrEmpty(result.Numbers))
                    {
                        numbers.Push(int.Parse(result.Numbers));
                    }

                    result = new Result() { HasSpecialCharacter = false };
                }
            }
        }

        return numbers.Sum();
    }

    [GeneratedRegex(@"[*@#+$&%=\-\/]")]
    private static partial Regex SpecialChar();
}