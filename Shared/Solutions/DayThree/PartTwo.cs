namespace Shared.Solutions.DayThree;

public static partial class PartTwo
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

    public static List<Position> GetGearCoordinates(List<string> schematic)
    {
        List<Position> starCoordinates = new();
        for (int i = 0; i < schematic.Count; i++)
        {
            for (int j = 0; j < schematic.Count; j++)
            {
                if (schematic[i][j] != '*') continue;
                Position position = new() { X = j, Y = i };
                starCoordinates.Add(position);
            }
        }

        return starCoordinates;
    }

    public static List<Position>? NeighboringRatios(List<string> schematic, Position currPosition)
    {
        List<Position> neighboringCoordinates = new();
        foreach (var direction in _directions)
        {
            var newPosition = new Position
            {
                X = currPosition.X + direction.X,
                Y = currPosition.Y + direction.Y
            };

            // Boundary check
            if (newPosition.X < 0 || newPosition.X >= schematic[0].Length ||
                newPosition.Y < 0 || newPosition.Y >= schematic.Count)
                continue;

            if (char.IsDigit(schematic[newPosition.Y][newPosition.X]))
            {
                if (!IsPartOfIdentifiedNumber(neighboringCoordinates.ToList(), newPosition))
                    neighboringCoordinates.Add(newPosition);
            }

            // Break if two unique digits are found
            if (neighboringCoordinates.Count == 2)
                break;
        }

        Console.WriteLine($"Neighboring Coordinates: {neighboringCoordinates.Count}");
        return neighboringCoordinates.Count > 1 ? neighboringCoordinates : null;
    }


    public static int GetFullNumberFromCoordinates(List<string> schematic, Position numCoordinates)
    {
        string lowSlice = schematic[numCoordinates.Y][0..(numCoordinates.X + 1)];
        string highSlice = schematic[numCoordinates.Y][(numCoordinates.X + 1)..];
        int lowSliceStopIndex = 0;
        int highSliceStopIndex = 0;

        for (int i = lowSlice.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(lowSlice[i]))
                break;
            lowSliceStopIndex = i;
        }

        for (int i = 0; i < highSlice.Length; i++)
        {
            highSliceStopIndex = i;
            if (!char.IsDigit(highSlice[i]))
                break;
        }

        lowSlice = lowSlice[lowSliceStopIndex..];
        highSlice = highSlice[0..(highSliceStopIndex)];

        return int.Parse(
            $"{lowSlice}{highSlice}");
    }

    private static bool IsPartOfIdentifiedNumber(List<Position> identifiedNumbers, Position position)
    {
        foreach (var identifiedPosition in identifiedNumbers)
        {
            // Check if the X values are adjacent (differ by 1) and have the same Y value
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
        List<int> numbers = new();
        for (int i = 0; i < starCoordinates.Count; i++)
        {
            Position currPosition = starCoordinates[i];
            List<Position>? neighboringCoordinates = NeighboringRatios(lines, currPosition);
            if (neighboringCoordinates is null)
                continue;
            int firstNum = GetFullNumberFromCoordinates(lines, neighboringCoordinates[0]);
            int secondNum = GetFullNumberFromCoordinates(lines, neighboringCoordinates[1]);
            numbers.Add(firstNum * secondNum);
        }

        return numbers.Sum();
    }
}