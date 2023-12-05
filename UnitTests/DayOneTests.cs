using Shared;
using Shared.Solutions.DayOne;

namespace UnitTests
{
    public class DayOneTests
    {
        [Fact]
        public void PartOneTest()
        {
            // arrange
            PathInput path = PathInputFactory.Create("One");
            List<string> input = Helpers.ReadInput(path.Test);

            // act
            int result = PartOne.Solve(input);

            // assert
            Assert.Equal(142, result);
        }

        [Fact]
        public void PartTwoTest()
        {
            // arrange
            PathInput path = PathInputFactory.Create("One", "Two");
            List<string> input = Helpers.ReadInput(path.Test);

            // act 
            int result = PartTwo.Solve(input);

            // assert
            Assert.Equal(281, result);
        }

        // [Fact]
        // public void PartTwoTestTwo()
        // {
        //     // arrange
        //     PathInput path = PathInputFactory.Create("One", "Two");
        //     List<string> input = Helpers.ReadInput(path.Input);
        //     
        //     // act
        //     int result = PartTwoTryTwo.Solve(input);
        //     
        //     // assert
        //     Assert.Equal(53539, result);
        // }
    }
}
