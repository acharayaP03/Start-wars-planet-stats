﻿using Star_wars_planets_stats.DTOs;
using Star_wars_planets_stats.UserInteractions;
using System.Text.Json;

namespace Star_wars_planets_stats.DataAccess;

public class PlanetsFromApiReader : IPlanetsReader
{
    private readonly IApiDataReader _apiDataReader;

    private readonly IApiDataReader _secondaryApiDataReader;

    private readonly IUserInteractor _userInteractor;
    public PlanetsFromApiReader(IApiDataReader apiDataReader,
                                IApiDataReader secondaryApiDataReader,
                                IUserInteractor userInteractor)
    {
        _apiDataReader = apiDataReader;
        _secondaryApiDataReader = secondaryApiDataReader;
        _userInteractor = userInteractor;
    }

    public async Task<IEnumerable<Planet>> Read()
    {
        string? json = null;

        IPrintHeader header = new PrintHeader("Star Wars Planets Stats", Console.WindowWidth, ConsoleColor.Red);

        header.PrintAppHeader();

        try
        {
            json = await _apiDataReader.Read("https://swapi.dev/", "api/planets");
        }
        catch (HttpRequestException ex)
        {
            _userInteractor.ShowMessage(
                "API request was unsuccessful. " +
                "Switching to mock data. " +
                "Exception message: " + ex.Message);
        }

        json ??= await _secondaryApiDataReader.Read("https://swapi.dev/", "api/planets");

        var root = JsonSerializer.Deserialize<Root>(json);

        return ToPlanets(root);
    }


    private static IEnumerable<Planet> ToPlanets(Root? root)
    {
        return root is null ? throw new ArgumentNullException(nameof(root)) : root.results.Select(planetDto => (Planet)planetDto);
    }
}