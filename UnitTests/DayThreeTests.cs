using Shared;
using Shared.Solutions.DayThree;

namespace UnitTests;

public class DayThreeTests
{
    private readonly List<string> _testInput;

    public DayThreeTests()
    {
        PathInput path = PathInputFactory.Create("Three");
        _testInput = Helpers.ReadInput(path.Test);
    }

    [Fact]
    public void CheckHasSpecialCharReturnsFalse()
    {
        // arrange
        PartOne.Position position = new PartOne.Position { X = 0, Y = 0 };

        // act
        bool result = PartOne.HasSpecialChar(_testInput, position);

        // assert
        Assert.False(result);
    }

    [Fact]
    public void CheckHasSpecialCharReturnsTrue()
    {
        // arrange
        PartOne.Position position = new PartOne.Position { X = 2, Y = 0 };


        // act
        bool result = PartOne.HasSpecialChar(_testInput, position);

        // assert
        Assert.True(result);
    }
    
    [Fact]
    public void CheckNumberContinuesReturnsFalse()
    {
        // arrange
        PartOne.Position position = new PartOne.Position { X = 2, Y = 0 };

        // act
        bool result = PartOne.NumberContinues(_testInput, position);

        // assert
        Assert.False(result);
    }
    
    [Fact]
    public void CheckNumberContinuesReturnsTrue()
    {
        // arrange
        PartOne.Position position = new PartOne.Position { X = 0, Y = 0 };

        // act
        bool result = PartOne.NumberContinues(_testInput, position);

        // assert
        Assert.True(result);
    }

    [Fact]
    public void PartOneTest()
    {
        // act
        int result = PartOne.Solve(_testInput);

        // assert
        Assert.Equal(4361, result);
    }
}