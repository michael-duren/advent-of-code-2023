using Shared;
using Shared.Solutions.DayFour;

namespace UnitTests
{
    public class DayFourTests
    {
        private readonly List<string> _testInput;
        // private readonly List<string> _input;

        public DayFourTests()
        {
            string testPath = PathInputFactory.Create("Four").Test;
            // string inputPath = PathInputFactory.Create("Four").Input;

            _testInput = Helpers.ReadInput(testPath);
            // _input = Helpers.ReadInput(inputPath);
        }

        [Fact]
        public void PartOneTest()
        {
            // arrange
            const int expected = 13;
            // act 
            int result = PartOne.Solve(_testInput);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PartTwoTest()
        {
            const int expected = 30;

            // act
            int result = PartTwo.Solve(_testInput);

            // assert
            Assert.Equal(expected, result);
        }
    }
}
