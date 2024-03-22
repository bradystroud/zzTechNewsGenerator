// See https://aka.ms/new-console-template for more information

// using SimpleFeedReader;

using CodeHollow.FeedReader;
using Microsoft.Extensions.Configuration;
using TechNewsGenerator.Helpers;
using TechNewsGenerator.Models;
using OpenAI_API;
using OpenAI_API.Models;

var feedLinks = FeedHelper.GetFeedsList();

var feeds = new List<FeedItem>();

foreach (var feed in feedLinks)
{
    try
    {
        var read = await FeedReader.ReadAsync(feed);
        feeds.AddRange(read.Items);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error reading feed: {feed}");
        Console.WriteLine(e);
        Console.WriteLine("These seem to break all the time, so let's just ignore it and move on");
    }
}

var thirdWednesday = DateTimeHelpers.GetMostRecentThirdWednesday(true);

var filteredItems = feeds.Where(i => i.PublishingDate > thirdWednesday)
    .OrderBy(i => i.PublishingDate)
    .ToList();

var articles = new List<Article>();
foreach (var i in filteredItems)
{
    Console.WriteLine($"{i.PublishingDate:g}\t{i.Title}\t{i.Link}");
    articles.Add(new Article
    {
        Title = i.Title,
        Date = i.PublishingDate,
        Url = i.Link
    });
}

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();
var config = builder.Build();

var api = new OpenAIAPI(config["OpenAIAPIKey"]);

var chat = api.Chat.CreateConversation();
chat.Model = Model.GPT4_Turbo;
chat.RequestParameters.Temperature = 0;

var prompt = $"""
              You are a tech news generator. I will provide a list of articles and you need to decide which ones are best for the SSW Tech News
              SSW Is a Software Consultancy focused on building .NET, Azure solutions but we do everything. We are based in Sydney, Australia.
              Pick 10-20 articles from the list, they should be the most important, impactful ones for developers. Avoid boring, basic articles e.g. security updates and avoid duplicates.
              
              Bad example: Azure Sphere OS version 24.03 is now available for evaluation (low impact)
              
              If there is a part 1 and 2, these are the same topic and should be considered one article.
              Make sure to include a few AI related articles.
              
              Prefer news that has actionable tasks for organisations.
              
              Okay Example: Microsoft was hacked (no action for organisations to take) 
              Good Example: .NET 6 is released (action is to upgrade) 

              Respond with only a markdown numbered list of the articles and the URL.
              Articles:

              {string.Join("\n", articles.Select(a => $"{a.Title} - {a.Url.ToString()}"))}

              """;

Console.WriteLine(prompt);

var result = await api.Chat.CreateChatCompletionAsync(prompt);

Console.WriteLine(result.Choices[0].Message.TextContent);