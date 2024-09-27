
IPrintHeader header = new PrintHeader()
{
    HeaderTitle = "Star Wars Planets Stats",
    Width = Console.WindowWidth,
    Color = ConsoleColor.Red
};


header.PrintAppHeader();

Console.ReadKey();
