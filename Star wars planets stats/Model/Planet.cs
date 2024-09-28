using Star_wars_planets_stats.DTOs;
using Star_wars_planets_stats.Utilities;

namespace Star_wars_planets_stats.Model;

public readonly record struct Planet : IPlanet
{
    public string Name { get; }

    public int Diameter { get; }

    public long? Population { get; }

    public int? SurfaceWater { get; }

    public Planet(string name, int diameter, long? population, int? surfaceWater)
    {

        if (name is null)
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

        long? population = planetDto.population.ToLongOrNull();

        int? surfaceWater = planetDto.surface_water.ToIntOrNull();

        return new Planet(name, diameter, population, surfaceWater);

    }
}