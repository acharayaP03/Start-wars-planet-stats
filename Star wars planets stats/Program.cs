
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
        string? json = null;

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

        var planets = ToPlanets(root);

        foreach (var planet in planets)
        {
            Console.WriteLine(planet);
        }
        Console.WriteLine();
        Console.WriteLine("The statistics fo which property would you like to see?. ");
        Console.WriteLine("population");
        Console.WriteLine("diameter");
        Console.WriteLine("surface");
        Console.WriteLine();


        var userChoice = Console.ReadLine();

        if (userChoice!.ToLower() == "population")
        {
            ShowStatistics(planets, "population", planet => planet.Population);
        }

        else if (userChoice!.ToLower() == "diameter")
        {
            ShowStatistics(planets, "diameter", planet => planet.Diameter);
        }
        else if (userChoice!.ToLower() == "surface")
        {
            ShowStatistics(planets, "surface water", planet => planet.SurfaceWater);
        }
        else
        {
            Console.WriteLine("Invalid choice please try again.");
        }
    }

    private IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }
       

        var planets = new List<Planet>();

        foreach (var planetDto in root.results)
        {
            Planet planet = (Planet)planetDto;

                planets.Add(planet);
        }
        return planets;
    }

    private void ShowStatistics(IEnumerable<Planet> planets, string propertyName, Func<Planet, int?> propertySelector)
    {
        var planetWithMaxPropertyValue = planets.MaxBy(propertySelector);
        Console.WriteLine($"Max {propertyName}  is: {propertySelector(planetWithMaxPropertyValue)} (planet: {propertySelector(planetWithMaxPropertyValue)})");

        var planetWithMinPropertyValue = planets.MinBy(propertySelector);
        Console.WriteLine($"Min {propertyName} is :{propertySelector(planetWithMinPropertyValue)} (planet: {propertySelector(planetWithMinPropertyValue)})");
    }
}

public readonly record struct Planet
{
    public string Name { get; }

    public int Diameter { get; }

    public int? Population { get; }

    public int? SurfaceWater { get; }

    public Planet(string name, int diameter, int? population, int? surfaceWater)
    {

        if(name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
        Diameter = diameter;
        Population = population;
        SurfaceWater = surfaceWater;
    }

    public static explicit operator Planet(Result planetDto)
    {
        var name = planetDto.name;
        var diameter = int.Parse(planetDto.diameter);

        int? population = planetDto.population.ToIntOrNull();

        int? surfaceWater = planetDto.surface_water.ToIntOrNull();

        return new Planet(name, diameter, population, surfaceWater);

    }
}

public static class StringExtensions
{
    public static int? ToIntOrNull(this string? value)
    {
        int? result = null;
        if (int.TryParse(value, out int parsedResult))
        {
            result = parsedResult;
        }
        return result;
    }
}
