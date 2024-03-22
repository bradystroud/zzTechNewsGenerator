namespace TechNewsGenerator.Helpers;

public static class FeedHelper
{
    private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "feeds.txt");

    public static IEnumerable<string?> GetFeedsList()
    {
        var feeds = new List<string?>();
        try
        {
            using var reader = new StreamReader(FilePath);
            while (reader.ReadLine() is { } line)
            {
                feeds.Add(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        return feeds;
    }
}