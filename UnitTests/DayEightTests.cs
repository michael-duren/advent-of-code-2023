using Shared;
using static Shared.Solutions.DayEight.PartOne;

namespace UnitTests
{
    public class DayEightTests
    {
        private readonly List<string> _testInput;
        private readonly List<string> _testInputTwo;
        private readonly List<string> _input;

        public DayEightTests()
        {
            string testPath = PathInputFactory.Create("Eight").Test;
            string testPathTwo = PathInputFactory.Create("Eight").TestTwo;
            string inputPath = PathInputFactory.Create("Eight").Input;

            _testInput = Helpers.ReadInput(testPath);
            _input = Helpers.ReadInput(inputPath);
            _testInputTwo = Helpers.ReadInput(testPathTwo);
        }

        [Fact]
        public void PartOneTestInputOne()
        {
            // arrange
            const int expected = 2;
            // act 
            int result = Solve(_testInput);

            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void PartOneTestInputTwo()
        {
            // arrange
            const int expected = 6;
            // act 
            int result = Solve(_testInputTwo);

            // assert
            Assert.Equal(expected, result);
        }
    }
}
