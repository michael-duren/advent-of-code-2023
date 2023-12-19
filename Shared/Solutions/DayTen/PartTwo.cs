using static Shared.Helpers;

namespace Shared.Solutions.DayTen
{
    public static class PartTwo
    {
        public readonly struct Coords
        {
            public int X { get; init; }
            public int Y { get; init; }

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
            public Coords Direction { get; init; }
            public Tile[] AllowedTilesTo { get; init; }
            public Tile[] AllowedTilesFrom { get; set; }
        }

        public enum Tile
        {
            Vertical = '|',
            Horizontal = '-',
            NorthEast = 'L',
            NorthWest = 'J',
            SouthWest = '7',
            SouthEast = 'F',
            Start = 'S',
            Ground = '.',
            Path = 'X',
            Fill = '0'
        }


        public static int Solve(List<string> input)
        {
            char[,] maze = ParseInput(input);
            Result<Coords> start = FindStartingPoint(maze);

            if (!string.IsNullOrEmpty(start.Err)) throw new Exception("Error parsing starting point");

            bool[,] seen = new bool[maze.GetUpperBound(0) + 1, maze.GetUpperBound(1) + 1];
            List<Coords> path = [];

            foreach (Move move in Moves)
            {
                if (Walk(move, start.Ok, maze, seen, path))
                {
                    break;
                }
            }

            // Fill in from each side of the maze
            FloodFill(maze, new Coords() { X = 0, Y = 0 });
            FloodFill(maze, new Coords() { X = maze.GetUpperBound(1), Y = 0 });
            FloodFill(maze, new Coords() { X = maze.GetUpperBound(1), Y = maze.GetUpperBound(0) });
            FloodFill(maze, new Coords() { X = 0, Y = maze.GetUpperBound(0) });

            int internalChars = 0;

            for (int i = 0; i <= maze.GetUpperBound(0); i++)
            {
                for (int j = 0; j < maze.GetUpperBound(1); j++)
                {
                    char curr = maze[i, j];
                    if (curr != (char)Tile.Fill && curr != (char)Tile.Start && curr != (char)Tile.Path)
                    {
                        internalChars++;
                    }
                }
            }

            PrintMaze(maze);

            return internalChars;
        }

        public static void FloodFill(char[,] maze, Coords coords)
        {
            if (IsOutOfBounds(maze, coords))
            {
                return;
            }

            if (maze[coords.Y, coords.X] == (char)Tile.Fill || maze[coords.Y, coords.X] == (char)Tile.Path)
            {
                return;
            }

            maze[coords.Y, coords.X] = (char)Tile.Fill;

            foreach (Move move in Moves)
            {
                FloodFill(maze, new Coords() { X = coords.X + move.Direction.X, Y = coords.Y + move.Direction.Y });
            }
        }

        public static bool Walk(Move nextMove, Coords curr, char[,] maze, bool[,] seen,
            List<Coords> path)
        {
            Coords next = new()
            {
                X = nextMove.Direction.X + curr.X,
                Y = nextMove.Direction.Y + curr.Y
            };

            if (IsOutOfBounds(maze, next))
            {
                return false; // if out of bounds return
            }

            char currTile = maze[curr.Y, curr.X];
            char nextTile = maze[next.Y, next.X];

            if (nextTile == (char)Tile.Start && path.Count > 0 &&
                nextMove.AllowedTilesFrom.Any(t => (char)t == currTile))
            {
                path.Add(next);
                return true; // if we find end count move
            }

            if (seen[next.Y, next.X])
            {
                return false; // if we have already seen return
            }

            // if all the allowed to move to tiles do not equal the next tile. OR if all the moveFrom tiles do not equal the current tile
            bool validMove = (nextMove.AllowedTilesFrom.Any(t => (char)t == currTile) &&
                              nextMove.AllowedTilesTo.Any(t => (char)t == nextTile)) ||
                             (currTile == (char)Tile.Start && nextMove.AllowedTilesTo.Any(t => (char)t == nextTile));
            if (!validMove)
            {
                return false; // invalid move
            }

            seen[curr.Y, curr.X] = true;
            path.Add(next);


            foreach (Move move in Moves)
            {
                if (Walk(move, next, maze, seen, path))
                {
                    maze[next.Y, next.X] = 'X';
                    return true;
                }
            }

            _ = path.Remove(next);
            return false;
        }

        private static bool IsOutOfBounds(char[,] maze, Coords coords)
        {
            return coords.X > maze.GetUpperBound(1) || coords.Y > maze.GetUpperBound(0) || coords.X < 0 || coords.Y < 0;
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
        [
            new()
            {
                Direction = new Coords { X = 0, Y = -1 }, // up
                AllowedTilesTo =
                [
                    Tile.Vertical,
                    Tile.SouthEast,
                    Tile.SouthWest
                ],
                AllowedTilesFrom =
                [
                    Tile.Vertical,
                    Tile.NorthEast,
                    Tile.NorthWest
                ],
            },
            new()
            {
                Direction = new Coords() { X = 1, Y = 0 }, // go right
                AllowedTilesTo =
                [
                    Tile.Horizontal,
                    Tile.SouthWest,
                    Tile.NorthWest
                ],
                AllowedTilesFrom =
                [
                    Tile.Horizontal,
                    Tile.SouthEast,
                    Tile.NorthEast
                ]
            },
            new()
            {
                Direction = new Coords() { X = 0, Y = 1 }, // go down
                AllowedTilesTo =
                [
                    Tile.Vertical,
                    Tile.NorthEast,
                    Tile.NorthWest
                ],
                AllowedTilesFrom =
                [
                    Tile.Vertical,
                    Tile.SouthEast,
                    Tile.SouthWest
                ]
            },
            new()
            {
                Direction = new Coords() { X = -1, Y = 0 }, // go left
                AllowedTilesTo =
                [
                    Tile.Horizontal,
                    Tile.NorthEast,
                    Tile.SouthEast
                ],
                AllowedTilesFrom =
                [
                    Tile.Horizontal,
                    Tile.NorthWest,
                    Tile.SouthWest
                ]
            }
        ];
    }
}