using Star_wars_planets_stats.Model;

public class PlanetStaticsAnalyzer : IPlanetStatisticsAnalyzer
{
    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;

    public PlanetStaticsAnalyzer(IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    public void Analyze(IEnumerable<Planet> planets)
    {

        var propertyNamesToSelectorMapping = new Dictionary<string, Func<Planet, long?>>
        {
            { "population", planet => planet.Population },
            { "diameter", planet => planet.Diameter },
            { "surface water", planet => planet.SurfaceWater }
        };


        var userChoice = _planetsStatsUserInteractor.ChooseStaticticsToDisplay(propertyNamesToSelectorMapping.Keys);

        if (userChoice is null || !propertyNamesToSelectorMapping.ContainsKey(userChoice.ToLower()))
        {
            //Console.WriteLine("Invalid choice please try again.");
            _planetsStatsUserInteractor.ShowMessage("Invalid choice please try again.");
        }
        else
        {
            ShowStatistics(planets, userChoice, propertyNamesToSelectorMapping[userChoice.ToLower()]);
        }
    }

    private static void ShowStatistics(IEnumerable<Planet> planets, string propertyName, Func<Planet, long?> propertySelector)
    {
        ShowStatistics("Max", planets.MaxBy(propertySelector), propertyName, propertySelector);
        ShowStatistics("Min", planets.MinBy(propertySelector), propertyName, propertySelector);
    }

    private static void ShowStatistics(string description, Planet selectedPlanet, string propertyName, Func<Planet, long?> propertySelector)
    {
        Console.WriteLine($"{description} {propertyName}  is: {propertySelector(selectedPlanet)} (planet: {selectedPlanet.Name})");
    }

}

