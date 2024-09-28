namespace Star_wars_planets_stats.UserInteractions;

public class PlanetsStatsUserInteractor : IPlanetsStatsUserInteractor
{
    private readonly IUserInteractor _userInteractor;

    public PlanetsStatsUserInteractor(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    string? IPlanetsStatsUserInteractor.ChooseStaticticsToDisplay(IEnumerable<string> propertiesThatCanBeChosen)
    {
        _userInteractor.ShowMessage(Environment.NewLine);
        _userInteractor.ShowMessage("The statistics fo which property would you like to see?. ");
        _userInteractor.ShowMessage(string.Join(Environment.NewLine, propertiesThatCanBeChosen));

        return _userInteractor.ReadFromUser();
    }

    void IPlanetsStatsUserInteractor.Show(IEnumerable<Planet> planets)
    {
        Console.WriteLine("Planets:" + planets);
    }

    void IPlanetsStatsUserInteractor.ShowMessage(string message)
    {
        _userInteractor.ShowMessage(message);
    }
}