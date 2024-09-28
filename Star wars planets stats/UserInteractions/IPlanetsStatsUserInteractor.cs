using Star_wars_planets_stats.Model;

public interface IPlanetsStatsUserInteractor
{
    void Show(IEnumerable<Planet> planets);

    string? ChooseStaticticsToDisplay(IEnumerable<string> propertiesThatCanBeChosen);

    void ShowMessage(string message);
}

