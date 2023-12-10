using Shared;
using static Shared.Solutions.DayNine.PartTwo;

namespace UnitTests
{
    public class DayNinePartTwoTests
    {

        private readonly List<string> _testInput;
        private readonly List<string> _input;

        public DayNinePartTwoTests()
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
            const long expected = 2;

            // act 
            long actual = Solve(_testInput);

            // assert
            Assert.Equal(expected, actual);
        }

        // [Fact]
        // public void PartOne_GetsCorrectInputAnswer()
        // {
        //     // arrange
        //     const long expected = 2174807968;
        //
        //     // act 
        //     long actual = Solve(_input);
        //
        //     // assert
        //     Assert.Equal(expected, actual);
        // }

    }
}
