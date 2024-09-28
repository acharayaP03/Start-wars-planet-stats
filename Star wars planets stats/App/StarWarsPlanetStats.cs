
namespace Star_wars_planets_stats.App;

public class StarWarsPlanetStats
{

    private readonly IPlanetsReader _planetsReader;



    private readonly IPlanetStatisticsAnalyzer _planetStatisticsAnalyzer;

    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;

    public StarWarsPlanetStats(IPlanetsReader planetsReader,
                               IPlanetStatisticsAnalyzer planetStatisticsAnalyzer,
                               IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsReader = planetsReader;
        _planetStatisticsAnalyzer = planetStatisticsAnalyzer;
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    public async Task Run()
    {
        var planets = await _planetsReader.Read();
        _planetsStatsUserInteractor.Show(planets);

        _planetStatisticsAnalyzer.Analyze(planets);
    }

}
