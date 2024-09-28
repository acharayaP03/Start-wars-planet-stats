using Star_wars_planets_stats.Model;

public interface IPlanetsReader
{
    Task<IEnumerable<Planet>> Read();
}

