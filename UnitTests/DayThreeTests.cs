using Shared;
using Shared.Solutions.DayThree;

namespace UnitTests;

public class DayThreeTests
{
    [Fact]
    public void PartOneTest()
    {
        // arrange
        PathInput path = PathInputFactory.Create("Three");
        List<string> input = Helpers.ReadInput(path.Test);

        // act
        int result = PartOne.Solve(input);

        // assert
        Assert.Equal(4361, result);
    }
    
}
