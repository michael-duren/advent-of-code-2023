using Shared;
using Shared.Solutions.DaySeven;

namespace UnitTests
{
    public class DaySevenTests
    {
        private readonly List<string> _testInput;
        private readonly List<string> _input;

        public DaySevenTests()
        {
            string testPath = PathInputFactory.Create("Seven").Test;
            string inputPath = PathInputFactory.Create("Seven").Input;

            _testInput = Helpers.ReadInput(testPath);
            _input = Helpers.ReadInput(inputPath);
        }

        [Fact]
        public void PartOneTest()
        {
            // arrange
            const int expected = 6440;
            // act 
            int result = PartOne.Solve(_testInput);

            // assert
            Assert.Equal(expected, result);
        }

        // [Fact]
        // public void PartTwoTest()
        // {
        //     // arrange
        //     const long expected = 71503;
        //     // act 
        //     long result = PartTwo.Solve(_testInput);
        // 
        //     // assert
        //     Assert.Equal(expected, result);
        // }
    }
}
