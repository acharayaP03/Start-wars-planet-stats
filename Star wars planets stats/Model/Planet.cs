using Star_wars_planets_stats.DTOs;
using Star_wars_planets_stats.Utilities;

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

