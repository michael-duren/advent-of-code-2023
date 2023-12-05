using Shared;
using Shared.Solutions.DayFive;

namespace UnitTests
{
    public class DayFiveTests
    {
        private readonly List<string> _testInput;
        private readonly List<string> _input;

        public DayFiveTests()
        {
            string testPath = PathInputFactory.Create("Five").Test;
            string inputPath = PathInputFactory.Create("Five").Input;

            _testInput = Helpers.ReadInput(testPath);
            _input = Helpers.ReadInput(inputPath);
        }

        [Fact]
        public void PartOneTest()
        {
            // arrange
            const int expected = 35;
            // act 
            int result = PartOne.Solve(_testInput);

            // assert
            Assert.Equal(expected, result);
        }

        // [Fact]
        // public void PartTwoTest()
        // {
        //     const int expected = 30;
        //
        //     // act
        //     int result = PartTwo.Solve(_testInput);
        //
        //     // assert
        //     Assert.Equal(expected, result);
        // }
    }
}
