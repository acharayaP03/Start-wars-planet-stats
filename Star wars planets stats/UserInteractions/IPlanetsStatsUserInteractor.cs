public interface IPlanetsStatsUserInteractor
{
    void Show(IEnumerable<Planet> planets);

    string? ChooseStaticticsToDisplay(IEnumerable<string> propertiesThatCanBeChosen);

    void ShowMessage(string message);
}

