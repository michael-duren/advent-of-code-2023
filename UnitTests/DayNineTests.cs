using Shared;
using static Shared.Solutions.DayNine.PartOne;

namespace UnitTests
{
    public class DayNineTests
    {
        private readonly List<string> _testInput;
        private readonly List<string> _input;

        public DayNineTests()
        {
            string testPath = PathInputFactory.Create("Nine").Test;
            string inputPath = PathInputFactory.Create("Nine").Input;

            _testInput = Helpers.ReadInput(testPath);
            _input = Helpers.ReadInput(inputPath);
        }

        [Fact]
        public void PartOne_GetsCorrectTestAnswer()
        {
            // arrange
            const long expected = 114;

            // act 
            long actual = Solve(_testInput);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartOne_GetsCorrectInputAnswer()
        {
            // arrange
            const long expected = 2174807968;

            // act 
            long actual = Solve(_input);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetListsToZero_CorrectlyReturnsList()
        {
            // arrange
            List<int> firstLine = new() { 0, 3, 6, 9, 12, 15 };
            List<int> firstLineTwo = new() { 1, 3, 6, 10, 15, 21, };
            List<List<int>> empty = new();
            List<List<int>> emptyTwo = new();
            // expected
            int expected = 18;
            int expectedTwo = 28;

            // act
            var result = PredictNextNumber(firstLine);
            var resultTwo = PredictNextNumber(firstLineTwo);

            // assert
            Assert.Equal(expected, result);
            Assert.Equal(expectedTwo, resultTwo);
        }
    }
}