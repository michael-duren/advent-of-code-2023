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
            string testPath = PathInputFactory.Create("Seven").Test;
            string inputPath = PathInputFactory.Create("Seven").Input;

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

        [Theory]
        [InlineData("J3T3T", HandType.FullHouse)] // Full House
        [InlineData("6Q499", HandType.OnePair)] // One Pair
        [InlineData("8J3AA", HandType.ThreeOfAKind)] // Three Of a kind
        [InlineData("A73AA", HandType.ThreeOfAKind)] // Three of a Kind
        [InlineData("28445", HandType.OnePair)] // One Pair
        [InlineData("A9QAA", HandType.ThreeOfAKind)] // Three of a Kind
        [InlineData("47353", HandType.OnePair)] // One Pair
        [InlineData("AQ7A9", HandType.OnePair)] // Two Pair
        [InlineData("QT6JJ", HandType.ThreeOfAKind)] // Three of a Kind with Joker
        [InlineData("J6K38", HandType.OnePair)] // One Pair
        [InlineData("5JA65", HandType.ThreeOfAKind)] // Two Pair with Joker
        [InlineData("737QJ", HandType.ThreeOfAKind)] // One Pair with Joker
        [InlineData("QQ56J", HandType.ThreeOfAKind)] // Three of a Kind with Joker
        [InlineData("5T666", HandType.ThreeOfAKind)] // Three of a Kind
        [InlineData("4486Q", HandType.OnePair)] // One Pair
        [InlineData("J6566", HandType.FourOfAKind)] // Three of a Kind with Joker
        [InlineData("3TT88", HandType.TwoPair)] // Two Pair
        [InlineData("KKK8K", HandType.FourOfAKind)] // Four of a Kind
        [InlineData("8Q884", HandType.ThreeOfAKind)] // One Pair
        [InlineData("T5T74", HandType.OnePair)] // One Pair
        [InlineData("32J22", HandType.FourOfAKind)] // Three of a Kind with Joker
        // Add more test cases as needed
        public void GetHandType_ReturnsCorrectHandType(string cards, HandType expectedHandType)
        {
            // Arrange
            var hand = new Hand { Cards = cards };

            // Act
            var resultHandType = GetHandType(hand);

            // Assert
            Assert.Equal(expectedHandType, resultHandType);
        }
    }
}