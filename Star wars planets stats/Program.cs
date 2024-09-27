
using Star_wars_planets_stats.ApiDataReader;
using Star_wars_planets_stats.DTOs;
using System.Text.Json;

IPrintHeader header = new PrintHeader()
{
    HeaderTitle = "Star Wars Planets Stats",
    Width = Console.WindowWidth,
    Color = ConsoleColor.Red
};
header.PrintAppHeader();

IApiDataReader apiDataReader = new ApiDataReader();
var json = await apiDataReader.Read("https://swapi.dev/", "api/planets");

var root = JsonSerializer.Deserialize<Root>(json);


Console.WriteLine("Please any key to exit...");
Console.ReadKey();
