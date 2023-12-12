using static Shared.Helpers;

namespace Shared.Solutions.DayTen
{
    public static class PartOne
    {
        public struct Coords
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public struct Move
        {
            public Coords Direction { get; set; }
            public Tile[] AllowedTiles { get; set; }
        }

        public enum Tile
        {
            Vertical = '|',
            Horizontal = '-',
            NorthEast = 'L',
            NorthWest = 'J',
            SouthWest = '7',
            SouthEast = 'F',
            Ground = '.',
            Start = 'S'
        }

        public static Move[] Moves { get; set; } =
        {
            new()
            {
                Direction = new Coords { X = 0, Y = -1 }, // up
                AllowedTiles = new[]
                {
                    Tile.Vertical,
                    Tile.SouthEast,
                    Tile.SouthWest
                }
            },
            new()
            {
                Direction = new Coords() { X = 1, Y = 0 }, // go right
                AllowedTiles = new[]
                {
                    Tile.Horizontal,
                    Tile.NorthEast,
                    Tile.SouthEast
                }
            },
            new()
            {
                Direction = new Coords() { X = 0, Y = 1 },
                AllowedTiles = new[]
                {
                    Tile.Vertical,
                    Tile.NorthEast,
                    Tile.NorthWest
                }
            },
            new()
            {
                Direction = new Coords() { X = -1, Y = 0 },
                AllowedTiles = new[]
                {
                    Tile.Horizontal,
                    Tile.NorthWest,
                    Tile.NorthWest
                }
            }
        };


        public static int Solve(List<string> input)
        {
            char[,] map = ParseInput(input);
            Result<Coords> start = FindStartingPoint(map);
            return 0;
        }

        public static bool Walk(Move nextMove, Coords curr, char[,] maze, ref int steps, List<Coords> seen)
        {
            curr.X = nextMove.Direction.X + curr.X;
            curr.Y = nextMove.Direction.Y + curr.Y;

            if (curr.X >= maze.GetUpperBound(1) || curr.Y >= maze.GetUpperBound(0) || curr.X < 0 || curr.Y < 0)
            {
                return false; // if out of bounds return
            }

            if (seen.Any(c => c.X == curr.X && c.Y == curr.Y))
            {
                return false; // if we have already seen return
            }

            char nextTile = maze[curr.Y, curr.X];

            if (nextTile == (char)Tile.Start)
            {
                steps++;
                return true; // if we find end count move
            }

            if (nextMove.AllowedTiles.All(t => (char)t != nextTile))
            {
                return false; // if we cannot move here return false
            }

            seen.Add(curr);

            foreach (Move move in Moves)
            {
                if (!Walk(move, curr, maze, ref steps, seen)) continue;
                steps++;
                return true;
            }

            return false;
        }

        public static char[,] ParseInput(List<string> input)
        {
            char[,] matrix = new char[input.Count, input[0].Length];

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    matrix[i, j] = input[i].ToCharArray()[j];
                }
            }

            return matrix;
        }

        public static Result<Coords> FindStartingPoint(char[,] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map.GetUpperBound(1); j++)
                {
                    if (map[i, j] == (char)Tile.Start)
                    {
                        return Ok(new Coords { X = j, Y = i });
                    }
                }
            }

            return Err<Coords>("Could not find starting point");
        }

        // TODO: Find total loop points
        // TODO: Derive farthest point from total point
    }
}