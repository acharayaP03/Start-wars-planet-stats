
using Star_wars_planets_stats.ApiDataReader;
using Star_wars_planets_stats.App;
using Star_wars_planets_stats.DataAccess;
using Star_wars_planets_stats.UserInteractions;


try
{
    var consoleUserInteractor = new ConsoleUserInteractor();

    var planetsStatsUserInteractor = new PlanetsStatsUserInteractor(consoleUserInteractor);

    await new StarWarsPlanetStats(
        new PlanetsFromApiReader(
            new ApiDataReader(),
            new MockStarWarsApiDataReader(), consoleUserInteractor),
        new PlanetStaticsAnalyzer(planetsStatsUserInteractor), planetsStatsUserInteractor).Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occured: {ex.Message}");
}


Console.WriteLine("Please any key to exit...");
Console.ReadKey();

