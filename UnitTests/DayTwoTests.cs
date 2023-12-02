using Shared;
using Shared.Solutions.DayTwo;

namespace UnitTests;

public class DayTwoTests
{
    [Fact]
    public void PartOneTest()
    {
        // arrange
        PathInput path = PathInputFactory.Create("Two");
        List<string> input = Helpers.ReadInput(path.Test);
        
        // act
        int result = DayTwo.SolvePartOne(input);
        
        // assert
        Assert.Equal(8, result);
    }
    [Fact]
    public void PartTwoTest()
    {
        // arrange
        PathInput path = PathInputFactory.Create("Two");
        List<string> input = Helpers.ReadInput(path.Test);
        
        // act
        int result = DayTwo.SolvePartTwo(input);
        
        // assert
        Assert.Equal(2286, result);
    }
    
}