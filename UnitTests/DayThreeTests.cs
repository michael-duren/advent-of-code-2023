using Shared;
using Shared.Solutions.DayThree;

namespace UnitTests
{
    public class DayThreeTests
    {
        private readonly List<string> _testInput;
        private readonly List<string> _input;

        public DayThreeTests()
        {
            PathInput path = PathInputFactory.Create("Three");
            _testInput = Helpers.ReadInput(path.Test);
            _input = Helpers.ReadInput(path.Input);
        }

        [Fact]
        public void CheckHasSpecialCharReturnsFalse()
        {
            // arrange
            PartOne.Position position = new() { X = 0, Y = 0 };

            // act
            bool result = PartOne.HasSpecialChar(_testInput, position);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void CheckHasSpecialCharReturnsTrue()
        {
            // arrange
            PartOne.Position position = new() { X = 2, Y = 0 };


            // act
            bool result = PartOne.HasSpecialChar(_testInput, position);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void CheckNumberContinuesReturnsFalse()
        {
            // arrange
            PartOne.Position position = new() { X = 2, Y = 0 };

            // act
            bool result = PartOne.NumberContinues(_testInput, position);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void CheckNumberContinuesReturnsTrue()
        {
            // arrange
            PartOne.Position position = new() { X = 0, Y = 0 };

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

        /*
         * Part Two Tests
         */
        [Fact]
        public void GetGearCoordinatesReturnsRightAmount()
        {
            // act
            List<PartTwo.Position> coords = PartTwo.GetGearCoordinates(_input);

            // assert
            Assert.Equal(345, coords.Count);
        }

        [Fact]
        public void GetFullNumberFromCoordinatesTest()
        {
            // arrange
            PartTwo.Position position = new() { X = 2, Y = 0 };

            // act
            int result = PartTwo.GetFullNumberFromCoordinates(_testInput, position);

            // assert
            Assert.Equal(467, result);
        }

        [Fact]
        public void GetFullNumberFromCoordinatesTestTwo()
        {
            // arrange
            PartTwo.Position position = new() { X = 1, Y = 14 };

            // act
            int result = PartTwo.GetFullNumberFromCoordinates(_input, position);

            // assert
            Assert.Equal(862, result);
        }

        [Fact]
        public void NeighboringRatiosDoesNotReturnNull()
        {
            // arrange
            // arrange
            PartTwo.Position position = new() { X = 5, Y = 8 };

            // act
            List<PartTwo.Position>? result = PartTwo.NeighboringRatios(_testInput, position);

            Assert.NotNull(result);
        }

        [Fact]
        public void NeighboringReturnsTwo()
        {
            // arrange
            PartTwo.Position position = new() { X = 3, Y = 14 };
            PartTwo.Position positionTwo = new() { X = 99, Y = 18 };

            // act
            List<PartTwo.Position>? result = PartTwo.NeighboringRatios(_input, position);
            List<PartTwo.Position>? resultTwo = PartTwo.NeighboringRatios(_input, positionTwo);

            // Assert
            Assert.Equal(2, result!.Count);
            Assert.Equal(2, resultTwo!.Count);
        }

        [Fact]
        public void NeighboringReturnsTwoFromBothDiagonalAndNumbersAreCorrect()
        {
            PartTwo.Position position = new() { X = 73, Y = 57 };

            List<PartTwo.Position>? result = PartTwo.NeighboringRatios(_input, position);

            Assert.Equal(2, result?.Count);

            Assert.Equal(237, PartTwo.GetFullNumberFromCoordinates(_input, result![0]));
            Assert.Equal(784, PartTwo.GetFullNumberFromCoordinates(_input, result[1]));
        }

        [Fact]
        public void NeighboringRatiosDoesNotReturnNullTwo()
        {
            // arrange
            // arrange
            PartTwo.Position position = new() { X = 4, Y = 2 };
            PartTwo.Position positionTwo = new() { X = 99, Y = 18 };

            // act
            List<PartTwo.Position>? result = PartTwo.NeighboringRatios(_input, position);
            List<PartTwo.Position>? resultTwo = PartTwo.NeighboringRatios(_input, positionTwo);

            Assert.NotNull(result);
            Assert.NotNull(resultTwo);
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
}
