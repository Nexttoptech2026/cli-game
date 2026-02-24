namespace FuxxyNights;

public static class PlayerOptionParser
{
    private static readonly IReadOnlyDictionary<string, PlayerOption> OptionByKey =
        new Dictionary<string, PlayerOption>(StringComparer.OrdinalIgnoreCase)
        {
            ["1"] = PlayerOption.Umbrella,
            ["umbrella"] = PlayerOption.Umbrella,

            ["2"] = PlayerOption.WaterPump,
            ["waterpump"] = PlayerOption.WaterPump,
            ["pump"] = PlayerOption.WaterPump,

            ["3"] = PlayerOption.Tent,
            ["tent"] = PlayerOption.Tent,

            ["4"] = PlayerOption.Blanket,
            ["blanket"] = PlayerOption.Blanket
        };

    public static bool TryParse(string? input, out PlayerOption option)
    {
        option = default;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        var normalized = Normalize(input);
        return OptionByKey.TryGetValue(normalized, out option);
    }

    private static string Normalize(string input)
    {
        return input.Trim().ToLowerInvariant().Replace(" ", string.Empty).Replace("-", string.Empty);
    }
}
