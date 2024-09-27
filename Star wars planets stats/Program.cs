
using Star_wars_planets_stats.ApiDataReader;
using Star_wars_planets_stats.DTOs;
using System.Text.Json;


try
{
    await new StarWarsPlanetStats(
        new ApiDataReader(),
        new MockStarWarsApiDataReader()
        ).Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occured: {ex.Message}");
}


Console.WriteLine("Please any key to exit...");
Console.ReadKey();

public class StarWarsPlanetStats
{
    private readonly IApiDataReader _apiDataReader;

    private readonly IApiDataReader _secondaryApiDataReader;
    public StarWarsPlanetStats(IApiDataReader apiDataReader, IApiDataReader secondarytApiDataReader )
    {
        _apiDataReader = apiDataReader;
        _secondaryApiDataReader = secondarytApiDataReader;
    }

    public  async Task Run()
    {
        string json = null;

        IPrintHeader header = new PrintHeader()
        {
            HeaderTitle = "Star Wars Planets Stats",
            Width = Console.WindowWidth,
            Color = ConsoleColor.Red
        };
        header.PrintAppHeader();

        try
        {
            json = await _apiDataReader.Read("https://swapi.dev/", "api/planets");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"API request was unsuccessfull. Switching to Mock data. {ex.Message}");
            return;
        }

        if (json is null)
        {
            json = await _secondaryApiDataReader.Read("https://swapi.dev/", "api/planets");
        }

        var root = JsonSerializer.Deserialize<Root>(json);
    }
}
