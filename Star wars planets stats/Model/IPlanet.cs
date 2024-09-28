using Star_wars_planets_stats.Model;

public interface IPlanet
{
    int Diameter { get; }
    string Name { get; }
    long? Population { get; }
    int? SurfaceWater { get; }

    bool Equals(object obj);
    bool Equals(Planet other);
    int GetHashCode();
    string ToString();
}