using Shared;
using static Shared.Solutions.DayTen.PartOne;

namespace UnitTests
{
    public class DayTenTests
    {
        private readonly List<string> _testInput;
        private readonly List<string> _testInputTwo;
        private readonly List<string> _input;

        public DayTenTests()
        {
            string testPath = PathInputFactory.Create("Ten").Test;
            string testPathTwo = PathInputFactory.Create("Ten").TestTwo;
            string inputPath = PathInputFactory.Create("Ten").Input;

            _testInput = Helpers.ReadInput(testPath);
            _testInputTwo = Helpers.ReadInput(testPathTwo);
            _input = Helpers.ReadInput(inputPath);
        }

        [Fact]
        public void ParseInput_CorrectlyCreatesTwoDArray()
        {
            // arrange
            char[,] expected =
            {
                { '.', '.', '.', '.', '.' },
                { '.', 'S', '-', '7', '.' },
                { '.', '|', '.', '|', '.' },
                { '.', 'L', '-', 'J', '.' },
                { '.', '.', '.', '.', '.' }
            };

            char[,] expectedTwo =
            {
                { '.', '.', 'F', '7', '.' },
                { '.', 'F', 'J', '|', '.' },
                { 'S', 'J', '.', 'L', '7' },
                { '|', 'F', '-', '-', 'J' },
                { 'L', 'J', '.', '.', '.' }
            };

            // expected
            char[,] result = ParseInput(_testInput);
            char[,] resultTwo = ParseInput(_testInputTwo);

            // assert
            Assert.Equal(expected, result);
            Assert.Equal(expectedTwo, resultTwo);
        }

        [Fact]
        public void Walk_ReturnsCorrectSteps()
        {
            char[,] maze = ParseInput(_testInput);
            Helpers.Result<Coords> start = FindStartingPoint(maze);
            bool[,] seen = new bool[maze.GetUpperBound(0), maze.GetUpperBound(1)];
            List<Coords> path = new();
            foreach (Move move in Moves)
            {
                if (Walk(move, start.Ok, maze, seen, path))
                    break;
            }

            Assert.Equal(8, path.Count);
        }

        [Fact]
        public void Walk_ReturnsCorrectStepsTwo()
        {
            char[,] maze = ParseInput(_testInputTwo);
            Helpers.Result<Coords> start = FindStartingPoint(maze);
            bool[,] seen = new bool[maze.GetUpperBound(0), maze.GetUpperBound(1)];
            List<Coords> path = new();
            foreach (Move move in Moves)
            {
                if (Walk(move, start.Ok, maze, seen, path))
                    break;
            }

            Assert.Equal(16, path.Count);
        }

        [Fact]
        public void PartOne_TestSolution_One()
        {
            // arrange
            const int expected = 4;

            // act 
            int actual = Solve(_testInput);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartOne_TestSolution_Two()
        {
            // arrange
            const int expected = 8;

            // act 
            int actual = Solve(_testInputTwo);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
