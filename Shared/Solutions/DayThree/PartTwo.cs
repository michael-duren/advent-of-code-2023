using System.Text;

namespace Shared.Solutions.DayThree;

public static class PartTwo
{
    private static readonly List<Position> _directions =
    [
        new Position { X = 0, Y = -1 }, // Go Up
        new Position { X = 1, Y = 0 }, // Go Right
        new Position { X = 0, Y = 1 }, // Go Down
        new Position { X = -1, Y = 0 }, // Go Left
        new Position { X = 1, Y = -1 }, // Go Diagonal Right
        new Position { X = -1, Y = -1 }, // Go Diagonal Left
        new Position { X = 1, Y = 1 }, // Go Diagonal Bottom Right
        new Position { X = -1, Y = 1 }, // Go Diagonal Bottom Left
    ];

    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // tested
    public static List<Position> GetGearCoordinates(List<string> schematic)
    {
        List<Position> starCoordinates = [];
        for (int i = 0; i < schematic.Count; i++)
        {
            for (int j = 0; j < schematic[0].Length; j++)
            {
                if (schematic[i][j] != '*') continue;
                Position position = new() { X = j, Y = i };
                starCoordinates.Add(position);
            }
        }

        return starCoordinates;
    }

    // tested
    public static List<Position>? NeighboringRatios(List<string> schematic, Position currPosition)
    {
        List<Position> neighboringCoordinates = [];
        foreach (Position direction in _directions)
        {
            Position newPosition = new()
            {
                X = currPosition.X + direction.X,
                Y = currPosition.Y + direction.Y
            };

            // Boundary check
            if (newPosition.X < 0 || newPosition.X >= schematic[0].Length ||
                newPosition.Y < 0 || newPosition.Y >= schematic.Count || !char.IsDigit(schematic[newPosition.Y][newPosition.X]))
                continue;

            if (!IsPartOfIdentifiedNumber([.. neighboringCoordinates], newPosition))
                neighboringCoordinates.Add(newPosition);
        }

        return neighboringCoordinates;
    }


    // tested
    public static int GetFullNumberFromCoordinates(List<string> schematic, Position numCoordinates)
    {
        StringBuilder fullNumber = new();

        // First, iterate left from the position to get the first part of the number
        for (int x = numCoordinates.X; x >= 0; x--)
        {
            if (char.IsDigit(schematic[numCoordinates.Y][x]))
            {
                // Insert the digit at the beginning of the full number
                fullNumber.Insert(0, schematic[numCoordinates.Y][x]);
            }
            else
            {
                // Break the loop if we find a non-digit character
                break;
            }
        }

        // Iterate right
        for (int x = numCoordinates.X + 1; x < schematic[numCoordinates.Y].Length; x++)
        {
            if (char.IsDigit(schematic[numCoordinates.Y][x]))
            {
                // Append the digit to the full number
                fullNumber.Append(schematic[numCoordinates.Y][x]);
            }
            else
            {
                // Break the loop if we find a non-digit character
                break;
            }
        }

        // Parse the constructed string to an integer
        return int.Parse(fullNumber.ToString());
    }


    private static bool IsPartOfIdentifiedNumber(List<Position> identifiedNumbers, Position position)
    {
        foreach (var identifiedPosition in identifiedNumbers)
        {
            if ((Math.Abs(identifiedPosition.X - position.X) == 1) && identifiedPosition.Y == position.Y)
            {
                return true; // The position is part of an already identified number
            }
        }

        return false; // The position is not part of any identified number
    }


    public static int Solve(List<string> lines)
    {
        List<Position> starCoordinates = GetGearCoordinates(lines);
        int numbers = 0;
        for (int i = 0; i < starCoordinates.Count; i++)
        {
            Position currPosition = starCoordinates[i];
            List<Position>? neighboringCoordinates = NeighboringRatios(lines, currPosition);
            if (neighboringCoordinates?.Count != 2)
                continue;
            int firstNum = GetFullNumberFromCoordinates(lines, neighboringCoordinates[0]);
            int secondNum = GetFullNumberFromCoordinates(lines, neighboringCoordinates[1]);
            numbers += firstNum * secondNum;
        }

        return numbers;
    }
}
