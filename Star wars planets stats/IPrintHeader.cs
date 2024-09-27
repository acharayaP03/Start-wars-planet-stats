
public interface IPrintHeader
{
    ConsoleColor Color { get; init; }
    string HeaderTitle { get; init; }
    int Padding { get; set; }
    int Width { get; init; }

    void PrintAppHeader();
}