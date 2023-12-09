using Shared;
using static Shared.Solutions.DaySeven.PartTwo;

namespace UnitTests
{
    public class DaySevenPartTwoTests
    {
        private readonly List<string> _testInput;
        private readonly List<string> _input;

        public DaySevenPartTwoTests()
        {
            string testPath = PathInputFactory.Create("Six").Test;
            string inputPath = PathInputFactory.Create("Six").Input;

            _testInput = Helpers.ReadInput(testPath);
            _input = Helpers.ReadInput(inputPath);
        }

        [Fact]
        public void PartTwoTest()
        {
            // arrange
            const long expected = 5905;
            // act 
            long result = Solve(_testInput);

            // assert
            Assert.Equal(expected, result);
        }
    }
}