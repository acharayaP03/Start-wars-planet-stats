using Star_wars_planets_stats.Model;

public interface IPlanetStatisticsAnalyzer
{
     void Analyze(IEnumerable<Planet> planets);
}

