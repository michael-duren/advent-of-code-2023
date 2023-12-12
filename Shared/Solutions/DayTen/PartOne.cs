using System.Xml.Schema;
using static Shared.Helpers;

namespace Shared.Solutions.DayTen
{
    public static class PartOne
    {
        public struct Coords
        {
            public int X { get; set; }
            public int Y { get; set; }

            public override bool Equals(object? obj)
            {
                if (obj is Coords other)
                {
                    return X == other.X && Y == other.Y;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
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


        public static int Solve(List<string> input)
        {
            char[,] maze = ParseInput(input);
            Result<Coords> start = FindStartingPoint(maze);
            if (!string.IsNullOrEmpty(start.Err)) throw new Exception("Error parsing starting point");
            bool[,] seen = new bool[input.Count, input[0].Length];
            int steps = 0;

            foreach (var move in Moves)
            {
                Walk(move, start.Ok, maze, ref steps, seen);
            }

            return steps / 2;
        }

        public static bool Walk(Move nextMove, Coords curr, char[,] maze, ref int steps, bool[,] seen)
        {
            Coords next = new Coords()
            {
                X = nextMove.Direction.X + curr.X,
                Y = nextMove.Direction.Y + curr.Y
            };

            if (next.X >= maze.GetUpperBound(1) || next.Y >= maze.GetUpperBound(0) || next.X < 0 || next.Y < 0)
            {
                return false; // if out of bounds return
            }

            if (seen[next.Y, next.X])
            {
                return false; // if we have already seen return
            }

            char nextTile = maze[next.Y, next.X];

            if (nextTile == (char)Tile.Start && steps > 0)
            {
                steps++;
                return true; // if we find end count move
            }

            if (nextMove.AllowedTiles.All(t => (char)t != nextTile))
            {
                return false; // invalid move
            }

            seen[curr.Y, curr.X] = true;
            steps++;

            foreach (Move move in Moves)
            {
                if (Walk(move, next, maze, ref steps, seen))
                {
                    return true;
                }
            }

            steps--;
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

        public static Move[] Moves { get; } =
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
                    Tile.SouthWest,
                    Tile.NorthWest
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
                    Tile.NorthEast,
                    Tile.SouthEast
                }
            }
        };

        // TODO: Find total loop points
        // TODO: Derive farthest point from total point
    }
}