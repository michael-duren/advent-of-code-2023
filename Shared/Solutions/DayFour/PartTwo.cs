namespace Shared.Solutions.DayFour
{
    public static class PartTwo
    {
        private record Round
        {
            public List<int> WinningNumbers { get; init; } = null!;
            public List<int> YourNumbers { get; init; } = null!;
            public int RoundNumber { get; set; }
        }

        private static Round ParseInput(string line)
        {
            string[] firstSplit = line.Split(":");
            string[] secondSplit = firstSplit[1].Split("|");

            Round round = new()
            {
                WinningNumbers = secondSplit[0].Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList(),
                YourNumbers = secondSplit[1].Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList()
            };
            return round;
        }

        private static int GetMatches(Round round)
        {
            return round.YourNumbers.Count(round.WinningNumbers.Contains);
        }

        private static void CountCards(Round currentCard, Dictionary<int, int> wonCards, List<Round> rounds)
        {
            int matches = GetMatches(currentCard);
            int currCardNum = currentCard.RoundNumber;

            // for each copy of a card we have we need to add its matches
            for (int i = 0; i < wonCards[currCardNum]; i++)
            {
                for (int j = 0; j < matches; j++)
                {
                    // get the next matches card number 
                    int nextCardNum = rounds[currCardNum + j].RoundNumber;
                    wonCards[nextCardNum] += 1;
                }
            }
        }

        public static int Solve(List<string> input)
        {
            List<Round> rounds = [];
            for (int i = 0; i < input.Count; i++)
            {
                Round round = ParseInput(input[i]);
                round.RoundNumber = i + 1;
                rounds.Add(round);
            }

            Dictionary<int, int> wonCards = Enumerable.Range(1, rounds.Count).ToDictionary(k => k, v => 1);

            foreach (Round round in rounds)
            {
                CountCards(round, wonCards, rounds);
            }

            return wonCards.Values.Sum();
        }
    }
}
