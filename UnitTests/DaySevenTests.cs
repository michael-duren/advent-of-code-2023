using Shared;
using static Shared.Solutions.DaySeven.PartOne;

namespace UnitTests
{
    public class DaySevenTests
    {
        private readonly List<string> _testInput;
        private readonly List<string> _input;

        public DaySevenTests()
        {
            string testPath = PathInputFactory.Create("Seven").Test;
            string inputPath = PathInputFactory.Create("Seven").Input;

            _testInput = Helpers.ReadInput(testPath);
            _input = Helpers.ReadInput(inputPath);
        }

        [Fact]
        public void Solve_SolvesTestInput()
        {
            // arrange
            const long expected = 6440;
            // act 
            long result = Solve(_testInput);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParseInput_CorrectlyParsesHands()
        {
            // Arrange
            var input = new List<string> { "2J2JT 100", "3K3T3 200" };

            // Act
            var hands = ParseInput(input);

            // Assert
            Assert.Equal(2, hands.Count);
            Assert.Equal(100, hands[0].BidAmount);
            Assert.Equal("2J2JT", hands[0].Cards);
            Assert.Equal(200, hands[1].BidAmount);
            Assert.Equal("3K3T3", hands[1].Cards);
        }

        [Fact]
        public void GetHandType_IdentifiesCorrectHandType()
        {
            // Arrange
            Hand fiveOfAKind = new() { Cards = "JJJJJ" };
            Hand fourOfAKind = new() { Cards = "JJJJ2" };
            Hand fullHouse = new() { Cards = "JJJ22" };
            Hand threeOfAKind = new() { Cards = "4A434" };
            Hand twoPair = new() { Cards = "4A4JA" };
            Hand onePair = new() { Cards = "4A4J2" };
            Hand highCard = new() { Cards = "4A3J2" };

            // Act
            HandType fiveOfAKindType = GetHandType(fiveOfAKind);
            HandType fourOfAKindType = GetHandType(fourOfAKind);
            HandType fullHouseType = GetHandType(fullHouse);
            HandType threeOfAKindType = GetHandType(threeOfAKind);
            HandType twoPairType = GetHandType(twoPair);
            HandType onePairType = GetHandType(onePair);
            HandType highCardType = GetHandType(highCard);

            // Assert
            Assert.Equal(HandType.FiveOfAKind, fiveOfAKindType);
            Assert.Equal(HandType.FourOfAKind, fourOfAKindType);
            Assert.Equal(HandType.FullHouse, fullHouseType);
            Assert.Equal(HandType.ThreeOfAKind, threeOfAKindType);
            Assert.Equal(HandType.TwoPair, twoPairType);
            Assert.Equal(HandType.OnePair, onePairType);
            Assert.Equal(HandType.HighCard, highCardType);
        }

        [Fact]
        public void SortHands_SortsHandsByHandType()
        {
            // Arrange
            List<Hand> hands = new()
            {
                new() { HandType = HandType.FiveOfAKind },
                new() { HandType = HandType.FourOfAKind },
                new() { HandType = HandType.TwoPair },
                new() { HandType = HandType.OnePair },
                new() { HandType = HandType.HighCard },
                new() { HandType = HandType.ThreeOfAKind },
            };

            // Act
            SortHands(hands);

            // Assert
            Assert.Equal(HandType.HighCard, hands[0].HandType);
            Assert.Equal(HandType.OnePair, hands[1].HandType);
            Assert.Equal(HandType.TwoPair, hands[2].HandType);
            Assert.Equal(HandType.ThreeOfAKind, hands[3].HandType);
            Assert.Equal(HandType.FourOfAKind, hands[4].HandType);
            Assert.Equal(HandType.FiveOfAKind, hands[5].HandType);
        }
    }
}
