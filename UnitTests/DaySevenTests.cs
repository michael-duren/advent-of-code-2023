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
            var input = new List<string> { "2J2JT 100", "3K3T3 200", "2J2KT 2", "3K3T3 2" };

            // Act
            var hands = ParseInput(input);

            // Assert
            Assert.Equal(4, hands.Count);
            Assert.Equal(100, hands[0].BidAmount);
            Assert.Equal("2J2JT", hands[0].Cards);
            Assert.Equal(200, hands[1].BidAmount);
            Assert.Equal("3K3T3", hands[1].Cards);
            Assert.Equal(2, hands[2].BidAmount);
            Assert.Equal("2J2KT", hands[2].Cards);
            Assert.Equal(2, hands[3].BidAmount);
            Assert.Equal("3K3T3", hands[3].Cards);
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
                new Hand() { HandType = HandType.HighCard },
                new() { HandType = HandType.ThreeOfAKind },
                new() { HandType = HandType.FiveOfAKind },
            };

            // Act
            SortHands(hands);

            // Assert
            Assert.Equal(HandType.HighCard, hands[0].HandType);
            Assert.Equal(HandType.HighCard, hands[1].HandType);
            Assert.Equal(HandType.OnePair, hands[2].HandType);
            Assert.Equal(HandType.TwoPair, hands[3].HandType);
            Assert.Equal(HandType.ThreeOfAKind, hands[4].HandType);
            Assert.Equal(HandType.FourOfAKind, hands[5].HandType);
            Assert.Equal(HandType.FiveOfAKind, hands[6].HandType);
            Assert.Equal(HandType.FiveOfAKind, hands[7].HandType);
        }

        [Fact]
        public void SortHandsByCardValues_SortsCorrectly()
        {
            // Arrange
            var hands = new List<Hand>
            {
                new Hand { Cards = "Q7QQ4" },
                new Hand { Cards = "Q7JQ4" },
                new Hand { Cards = "Q7JQ2" },
                new Hand { Cards = "Q7JQ3" },
            };

            // Act
            SortHandsByCardValues(hands);

            // Assert
            Assert.Equal("Q7JQ2", hands[0].Cards);
            Assert.Equal("Q7JQ3", hands[1].Cards);
            Assert.Equal("Q7JQ4", hands[2].Cards);
            Assert.Equal("Q7QQ4", hands[3].Cards);
        }

        [Fact]
        public void GetWinnings_CalculatesCorrectTotalWinnings()
        {
            // Arrange
            var hands = new List<Hand>
            {
                new Hand { Cards = "4A434", BidAmount = 100, HandType = HandType.OnePair },
                new Hand { Cards = "Q7JQ2", BidAmount = 200, HandType = HandType.TwoPair },
                new Hand { Cards = "Q7JQ2", BidAmount = 200, HandType = HandType.TwoPair },
                new Hand { Cards = "Q7JQ2", BidAmount = 800, HandType = HandType.TwoPair },
                new Hand { Cards = "Q7JQ2", BidAmount = 200, HandType = HandType.TwoPair },
                // Add more hands as needed
            };

            // Here, you might need to sort the hands as they would be sorted in the actual game
            // Since GetWinnings also sorts the hands, you may want to validate that aspect as well.

            // Expected winnings calculation based on sorted order and bid amounts
            long expectedWinnings =
                100 * 1 + 200 * 2 + 200 * 3 + 800 * 4 + 200 * 5; // Adjust this based on expected sorted order

            // Act
            long actualWinnings = GetWinnings(hands);

            // Assert
            Assert.Equal(expectedWinnings, actualWinnings);
        }

        [Theory]
        [InlineData("4A434", "Q7QQ2", -1)] // Hand A is lower than Hand B
        [InlineData("AQKTQ", "2Q3T2", 1)] // Hand A is higher than Hand B
        [InlineData("9K9D9", "Q7JQ2", 0)] // Hand types differ, cannot determine higher hand
        [InlineData("9K9D9", "AAAAA", 0)] // Hand types differ, cannot determine higher hand
        [InlineData("4Q5K6", "4Q5K6", 0)] // Hands are equal
        // Add more test cases as needed
        public void DetermineHigherHandByCard_ComparisonIsCorrect(string cardsA, string cardsB, sbyte expected)
        {
            // Arrange
            var handA = new Hand { Cards = cardsA, HandType = GetHandType(new Hand { Cards = cardsA }) };
            var handB = new Hand { Cards = cardsB, HandType = GetHandType(new Hand { Cards = cardsB }) };

            // Act
            var result = DetermineHigherHandByCard(handA, handB);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}