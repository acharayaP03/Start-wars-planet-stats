using Star_wars_planets_stats.Model;

namespace Star_wars_planets_stats.UserInteractions;

public class PlanetsStatsUserInteractor : IPlanetsStatsUserInteractor
{
    private readonly IUserInteractor _userInteractor;

    public PlanetsStatsUserInteractor(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public string? ChooseStaticticsToDisplay(IEnumerable<string> propertiesThatCanBeChosen)
    {
        _userInteractor.ShowMessage(Environment.NewLine);
        _userInteractor.ShowMessage("The statistics fo which property would you like to see?. ");
        _userInteractor.ShowMessage(string.Join(Environment.NewLine, propertiesThatCanBeChosen));

        return _userInteractor.ReadFromUser();
    }

    public void Show(IEnumerable<Planet> planets)
    {
        //foreach (var planet in planets)
        //{
        //    _userInteractor.ShowMessage(planet.ToString());
        //}

        TablePrinter.Print(planets);    
    }

    public void ShowMessage(string message)
    {
        _userInteractor.ShowMessage(message);
    }
}

public static class TablePrinter
{

   public static void Print<T>(IEnumerable<T> items)
    {
        const int columnWidth = 15;
        var properties = typeof(T).GetProperties();

        foreach(var property in properties)
        {
            //Console.Write($"{property.Name}|");
            Console.Write($"{{0,-{columnWidth}}}|", property.Name);

        }
        Console.WriteLine();
        Console.WriteLine(new string('-', columnWidth * properties.Length));



        foreach (var item in items)
        {
            foreach (var property in properties)
            {
                Console.Write($"{{0, -{columnWidth}}}", property.GetValue(item));
            }
            Console.WriteLine();
        }

    }
}
