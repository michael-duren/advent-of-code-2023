namespace Shared.Solutions.DayFive
{
    public static class PartOne
    {
        public readonly struct CategoryItem
        {
            public ulong DestinationRangeStart { get; init; }
            public ulong SourceRangeStart { get; init; }
            public ulong Range { get; init; }
        }

        public class Category
        {
            public string Name { get; init; } = null!;
            public List<CategoryItem> Items { get; init; } = new();
        }

        public static (List<Category>, List<ulong>) ParseInput(List<string> lines)
        {
            List<Category> categories = new();
            List<ulong> seeds = new();
            bool inCategory = false;

            foreach (string line in lines)
            {

                if (string.IsNullOrWhiteSpace(line))
                {
                    inCategory = false;
                    continue;
                }

                if (line.Contains("seeds"))
                    seeds = line.Split(" ").Skip(1).Select(x => ulong.TryParse(x, out ulong seed) ? seed : 0).ToList();

                if (line.Contains("map"))
                {
                    string categoryName = line.Split(" ").First();
                    inCategory = true;
                    Category category = new()
                    {
                        Name = categoryName,
                        Items = new List<CategoryItem>()
                    };
                    categories.Add(category);
                    continue;
                }

                if (inCategory && categories.Count > 0)
                {
                    string[] parts = line.Split(" ");

                    categories[^1].Items.Add(new CategoryItem
                    {
                        DestinationRangeStart = ulong.TryParse(parts[0], out ulong destinationRangeStart) ? destinationRangeStart : 0,
                        SourceRangeStart = ulong.TryParse(parts[1], out ulong sourceRangeStart) ? sourceRangeStart : 0,
                        Range = ulong.TryParse(parts[2], out ulong range) ? range : 0
                    });
                }

            }


            return (categories, seeds);
        }


        public static int Solve(List<string> lines)
        {
            (List<Category> categories, List<ulong> seeds) = ParseInput(lines);
            return 0;
        }
    }
}
