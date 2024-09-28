namespace Star_wars_planets_stats.UserInteractions;

public class PrintHeader : IPrintHeader
{

    public string HeaderTitle { get; init; }

    public int Width { get; init; }

    public int Padding { get; set; }

    public ConsoleColor Color { get; init; }

    public PrintHeader(string headerTitle, int width, ConsoleColor color)
    {
        HeaderTitle = headerTitle;
        Width = width;
        Color = color;
    }

    public void PrintAppHeader()
    {
        PrintAsterisksLine();

        PrintCenteredTitle();

        PrintAsterisksLine();
    }

    private void PrintAsterisksLine()
    {
        Console.ForegroundColor = Color; // Set the color for the asterisks
        Console.WriteLine(new string('*', Width));
        Console.ResetColor(); // Reset the console color to default after printing
    }

    private void PrintCenteredTitle()
    {
        // Calculate the padding to center the title
        int padding = (Width - HeaderTitle.Length - 4) / 2; // Subtract 4 for the surrounding asterisks and spaces
        string formattedTitle = "*" + new string(' ', padding) + HeaderTitle + new string(' ', padding) + "*";

        // If there's an extra space due to odd width, add one more space on the right
        if (formattedTitle.Length < Width)
        {
            formattedTitle = formattedTitle.Insert(formattedTitle.Length - 1, " ");
        }

        // Print the asterisks and spaces in yellow, and the title in red
        Console.ForegroundColor = ConsoleColor.Yellow; // Set color for surrounding asterisks
        Console.Write("*" + new string(' ', padding));

        Console.ForegroundColor = Color; // Set color for the title
        Console.Write(HeaderTitle);

        Console.ForegroundColor = ConsoleColor.Yellow; // Set color for the remaining spaces and asterisk
        Console.Write(new string(' ', padding) + "*");

        Console.ResetColor(); // Reset the console color to default after printing
        Console.WriteLine(); // Move to the next line
    }
}