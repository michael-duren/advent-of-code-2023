namespace Shared.Solutions.DayTen
{
    public static class PartOne
    {
        public static int Solve(List<string> input)
        {
            char[,] map = ParseInput(input);
            return 0;
        }
        // TODO: Parse Input to multi array
        public static char[,] ParseInput(List<string> input)
        {
            char[,] matrix = new char[input.Count, input[0].Length];

            for (int i = 0; i < input.Count; i++)
            {
                for(int j = 0; j < input[i].Length; j++)
                {
                    matrix[i, j] = input[i].ToCharArray()[j];
                }
            }

            return matrix;
        }
        // TODO: Find Starting Point
        // TODO: Find total loop points
        // TODO: Derive farthest point from total point
    }
}
