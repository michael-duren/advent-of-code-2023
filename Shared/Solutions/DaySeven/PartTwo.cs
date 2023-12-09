using System.Globalization;

namespace Shared.Solutions.DaySeven;

public static class PartTwo
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
        { 'J', 1 },
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { 'T', 10 },
        { 'Q', 12 },
        { 'K', 13 },
        { 'A', 14 }
    };

    public static long Solve(List<string> input)
    {
        List<Hand> hands = ParseInput(input);
        SortHands(hands);
        SortHandsByCardValues(hands);

        return GetWinnings(hands);
    }

    public static long GetWinnings(List<Hand> hands)
    {
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
        int jokerCount = hand.Cards.Count(c => c == 'J');

        if (jokerCount >= 4)
            return HandType.FiveOfAKind;

        Dictionary<char, int> cardCounts = new();
        foreach (char card in hand.Cards)
        {
            if (card == 'J')
                continue;
            if (cardCounts.ContainsKey(card))
            {
                cardCounts[card]++;
            }
            else
            {
                cardCounts.Add(card, 1);
            }
        }

        HandType currHand = cardCounts.ContainsValue(5) ? HandType.FiveOfAKind
            : cardCounts.ContainsValue(4) ? HandType.FourOfAKind
            : cardCounts.ContainsValue(3) && cardCounts.ContainsValue(2) ? HandType.FullHouse
            : cardCounts.ContainsValue(3) ? HandType.ThreeOfAKind
            : cardCounts.Values.Count(c => c == 2) == 2 ? HandType.TwoPair
            : cardCounts.ContainsValue(2) ? HandType.OnePair : HandType.HighCard;

        /*
         * joker count 3
         */
        if (jokerCount == 3 && currHand == HandType.OnePair) // 33JJJ
            return HandType.FiveOfAKind;
        if (jokerCount == 3 && currHand == HandType.HighCard) // 3AJJJ
            return HandType.FourOfAKind;
        /*
         * joker count 2
         */
        if (jokerCount == 2 && currHand == HandType.TwoPair) // AAJJ8
            return HandType.FourOfAKind;

        if (jokerCount == 2 && currHand == HandType.ThreeOfAKind) // JJAAA
            return HandType.FiveOfAKind;
        if (jokerCount == 2 && currHand == HandType.OnePair)
            return HandType.FourOfAKind;
        if (jokerCount == 2 && currHand == HandType.HighCard)
            return HandType.ThreeOfAKind;

        /*
         * joker count 1
         */
        if (jokerCount == 1) // J
        {
            currHand = currHand switch
            {
                HandType.HighCard => HandType.OnePair, // 1356J
                HandType.OnePair => HandType.ThreeOfAKind, // 1355J
                HandType.TwoPair => HandType.FullHouse,
                HandType.ThreeOfAKind => HandType.FourOfAKind,
                HandType.FourOfAKind => HandType.FiveOfAKind,
                HandType.FiveOfAKind => throw new Exception("Should not be here"),
                HandType.FullHouse => throw new Exception("Should not be here"),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        return currHand;
    }

    public static void SortHands(List<Hand> hands)
    {
        for (int i = 0; i < hands.Count - 1; i++)
        {
            for (int j = i + 1; j < hands.Count; j++)
            {
                if (hands[i].HandType > hands[j].HandType)
                {
                    (hands[i], hands[j]) = (hands[j], hands[i]);
                }
            }
        }
    }

    public static sbyte DetermineHigherHandByCard(Hand a, Hand b)
    {
        if (a.HandType != b.HandType) // if not same hand type we don't need to sort
            return 0;

        for (int i = 0; i < a.Cards.Length; i++)
        {
            // want to throw if cannot determine 
            int currA = _cardValues.ContainsKey(a.Cards[i])
                ? _cardValues[a.Cards[i]]
                : throw new Exception("Could not determine card value in hand A");
            int currB = _cardValues.ContainsKey(b.Cards[i])
                ? _cardValues[b.Cards[i]]
                : throw new Exception("Could not determine card value in hand B");

            if (currA > currB)
                return 1;
            if (currB > currA)
                return -1;
        }

        return 0;
    }

    public static void SortHandsByCardValues(List<Hand> hands)
    {
        for (int i = 0; i < hands.Count - 1; i++)
        {
            for (int j = i + 1; j < hands.Count; j++)
            {
                sbyte higherHand = DetermineHigherHandByCard(hands[i], hands[j]);
                if (higherHand == 1)
                {
                    (hands[i], hands[j]) = (hands[j], hands[i]);
                }
            }
        }
    }
}