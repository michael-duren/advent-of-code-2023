namespace Shared.Solutions.DaySeven;

public class PartOne
{
    private struct Hand
    {
        public List<string> Cards { get; set; }
        public int BidAmount { get; set; }
    }

    private static Dictionary<string, int> _cardValues = new()
    {
        { "2", 2 },
        { "3", 3 },
        { "4", 4 },
        { "5", 5 },
        { "6", 6 },
        { "7", 7 },
        { "8", 8 },
        { "9", 9 },
        { "10", 10 },
        { "J", 11 },
        { "Q", 12 },
        { "K", 13 },
        { "A", 14 }
    };

    public static int Solve(List<string> input)
    {
        List<Hand> hands = ParseInput(input);
        return 0;
    }

    private static List<Hand> ParseInput(List<string> input)
    {
        List<Hand> hands = new();
        foreach (string line in input)
        {
            string[] split = line.Split(" ");
            Hand hand = new()
            {
                BidAmount = int.Parse(split[1]),
                Cards = split[0].ToCharArray().Select(x => x.ToString()).ToList()
            };
            hands.Add(hand);
        }

        return hands;
    }
}