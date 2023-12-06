namespace Shared.Solutions.DayFive;

public static class PartTwo
{
    private class CategoryItem
    {
        public long DestinationRangeStart { get; init; }
        public long SourceRangeStart { get; init; }
        public long Range { get; init; }
    }

    private class Category
    {
        public string Name { get; init; } = null!; // for debugging
        public List<CategoryItem> Items { get; init; } = new();
    }


    public static long Solve(List<string> lines)
    {
        (List<Category> categories, List<long> seeds) = ParseInput(lines);
        long minLocation = long.MaxValue;
        object minLock = new();

        for (int i = 0; i < seeds.Count; i += 2)
        {
            Parallel.For(seeds[i], ((seeds[i] + seeds[i + 1]) + 1),
                seed =>
                {
                    long source = seed; // assign seed to source to start
                    foreach (Category category in categories) // foreach category get the destination and update source
                    {
                        foreach (CategoryItem item in category.Items)
                        {
                            if (source >= item.SourceRangeStart && source < item.SourceRangeStart + item.Range)
                            {
                                source = item.DestinationRangeStart + (source - item.SourceRangeStart);
                                break;
                            }
                        }
                    }


                    // after each category, add the source to the locations list
                    lock (minLock)
                    {
                        if (source < minLocation)
                        {
                            minLocation = source;
                        }
                    }
                }
            );
        }

        return minLocation;
    }


    private static (List<Category>, List<long>) ParseInput(List<string> lines)
    {
        List<Category> categories = new();
        List<long> seeds = new();
        bool inCategory = false;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                inCategory = false;
                continue;
            }

            if (line.Contains("seeds"))
            {
                seeds = line.Split(" ").Skip(1).Select(long.Parse).ToList();
            }

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
                    DestinationRangeStart = long.TryParse(parts[0], out long destinationRangeStart)
                        ? destinationRangeStart
                        : 0,
                    SourceRangeStart = long.TryParse(parts[1], out long sourceRangeStart) ? sourceRangeStart : 0,
                    Range = long.TryParse(parts[2], out long range) ? range : 0
                });
            }
        }

        return (categories, seeds);
    }

    private static IEnumerable<long> ULongRange(long start, long count)
    {
        for (long i = 0; i < count; i++)
        {
            yield return start + i;
        }
    }
}