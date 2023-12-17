using Shared;
using static Shared.Solutions.DayTen.PartTwo;

namespace UnitTests
{
    public class DayTenPartTwoTests
    {
        private readonly List<string> _testInput;
        private readonly List<string> _testInputTwo;
        private readonly List<string> _testPartTwoInputOne;
        private readonly List<string> _testPartTwoInputTwo;
        private readonly List<string> _testPartTwoInputThree;

        public DayTenPartTwoTests()
        {
            string testPath = PathInputFactory.Create("Ten").Test;
            string testPathTwo = PathInputFactory.Create("Ten").TestTwo;

            _testInput = Helpers.ReadInput(testPath);
            _testInputTwo = Helpers.ReadInput(testPathTwo);
            _testPartTwoInputOne = Helpers.ReadInput(PathInputFactory.Create("Ten", "Two").Test);
            _testPartTwoInputTwo = Helpers.ReadInput(PathInputFactory.Create("Ten", "Two").TestTwo);
            _testPartTwoInputThree = Helpers.ReadInput(PathInputFactory.Create("Ten", "Two").TestThree);
        }

        [Fact]
        public void Solve_ReturnsCorrectOnTestInputOne()
        {
            const int expected = 4;

            int result = Solve(_testPartTwoInputOne);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Solve_ReturnsCorrectOnTestInputTwo()
        {
            const int expected = 8;

            int result = Solve(_testPartTwoInputTwo);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Solve_ReturnsCorrectOnTestInputThree()
        {
            const int expected = 10;

            int result = Solve(_testPartTwoInputThree);

            Assert.Equal(expected, result);
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
            bool[,] seen = new bool[maze.GetUpperBound(0) + 1, maze.GetUpperBound(1) + 1];
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
            bool[,] seen = new bool[maze.GetUpperBound(0) + 1, maze.GetUpperBound(1) + 1];
            List<Coords> path = new();
            foreach (Move move in Moves)
            {
                if (Walk(move, start.Ok, maze, seen, path))
                {
                    break;
                }
            }

            Assert.Equal(16, path.Count);
        }
    }
}