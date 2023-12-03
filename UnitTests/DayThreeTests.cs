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

    [Fact]
    public void GetFullNumberFromCoordinatesTest()
    {
        // arrange
        PartTwo.Position position = new PartTwo.Position { X = 2, Y = 0 };

        // act
        int result = PartTwo.GetFullNumberFromCoordinates(_testInput, position);

        // assert
        Assert.Equal(467, result);
    }

    [Fact]
    public void NeighboringRatiosDoesNotReturnNull()
    {
        // arrange
        // arrange
        PartTwo.Position position = new PartTwo.Position { X = 5, Y = 8 };

        // act
        List<PartTwo.Position>? result = PartTwo.NeighboringRatios(_testInput, position);

        Assert.NotNull(result);
    }

    [Fact]
    public void PartTwoTest()
    {
        // act
        int result = PartTwo.Solve(_testInput);
        //
        Assert.Equal(467835, result);
    }
}