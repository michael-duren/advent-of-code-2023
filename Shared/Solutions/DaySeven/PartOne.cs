using System.Globalization;

namespace Shared.Solutions.DaySeven
{
    public static class PartOne
    {
        public struct Hand
        {
            public string Cards { get; init; }
            public int BidAmount { get; init; }
            public HandType HandType { get; set; }
        }

        public enum HandType
        {
            FiveOfAKind = 7,
            FourOfAKind = 6,
            FullHouse = 5,
            ThreeOfAKind = 4,
            TwoPair = 3,
            OnePair = 2,
            HighCard = 1
        }

        private static readonly Dictionary<char, int> _cardValues = new()
        {
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'T', 10 },
            { 'J', 11 },
            { 'Q', 12 },
            { 'K', 13 },
            { 'A', 14 }
        };

        public static long Solve(List<string> input)
        {
            List<Hand> hands = ParseInput(input);
            SortHands(hands);
            SortHandsByCardValues(hands);

            long totalWinnings = 0;

            for (int i = 0; i < hands.Count; i++)
            {
                totalWinnings += hands[i].BidAmount * (i + 1);
            }


            return totalWinnings;
        }

        public static List<Hand> ParseInput(List<string> input)
        {
            List<Hand> hands = new();
            foreach (string line in input)
            {
                string[] split = line.Split(" ");
                Hand hand = new()
                {
                    BidAmount = int.Parse(split[1], CultureInfo.InvariantCulture),
                    Cards = split[0]
                };
                hand.HandType = GetHandType(hand);
                hands.Add(hand);
            }

            return hands;
        }

        public static HandType GetHandType(Hand hand)
        {
            Dictionary<string, int> cardCounts = new();
            foreach (char card in hand.Cards)
            {
                string cardString = card.ToString();
                if (cardCounts.ContainsKey(cardString))
                {
                    cardCounts[cardString]++;
                }
                else
                {
                    cardCounts.Add(cardString, 1);
                }
            }

            return cardCounts.Count switch
            {
                1 => HandType.FiveOfAKind,
                2 => cardCounts.ContainsValue(4) ? HandType.FourOfAKind : HandType.FullHouse,
                3 => cardCounts.ContainsValue(3) ? HandType.ThreeOfAKind : HandType.TwoPair,
                4 => HandType.OnePair,
                _ => HandType.HighCard
            };
        }

        public static void SortHands(List<Hand> hands)
        {
            hands.Sort((a, b) => a.HandType.CompareTo(b.HandType));
        }

        public static sbyte DetermineHigherHandByCard(Hand a, Hand b)
        {
            if (a.HandType != b.HandType) // if not same hand type we don't need to sort
                return 0;

            for (int i = 0; i < a.Cards.Length; i++)
            {
                // want to throw if cannot determine 
                int currA = _cardValues.GetValueOrDefault(a.Cards[i]);
                int currB = _cardValues.GetValueOrDefault(b.Cards[i]);

                if (currA > currB)
                    return 1;
                if (currB > currA)
                    return -1;
            }

            return 0;
        }

        public static void SortHandsByCardValues(List<Hand> hands)
        {
            hands.Sort((a, b) => DetermineHigherHandByCard(a, b));
        }
    }
}