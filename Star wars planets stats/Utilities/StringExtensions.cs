

namespace Star_wars_planets_stats.Utilities;

public static class StringExtensions
{
    public static int? ToIntOrNull(this string? value)
    {
        return int.TryParse(value, out int parsedResult) ? parsedResult : null;
    }
}
