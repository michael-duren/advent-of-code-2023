using Shared;
using static Shared.Solutions.DayEight.PartTwo;

namespace UnitTests;

public class DayEightPartTwoTests
{
    private readonly List<string> _testInput;
    private readonly List<string> _input;

    public DayEightPartTwoTests()
    {
        string testPath = PathInputFactory.Create("Eight", "Two").Test;
        string inputPath = PathInputFactory.Create("Eight").Input;

        _testInput = Helpers.ReadInput(testPath);
        _input = Helpers.ReadInput(inputPath);
    }

    [Fact]
    public void PartOneTestInputOne()
    {
        // arrange
        const long expected = 6;
        // act 
        long result = Solve(_testInput);

        // assert
        Assert.Equal(expected, result);
    }
}