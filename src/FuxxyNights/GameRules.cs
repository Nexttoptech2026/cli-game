namespace FuxxyNights;

public enum PlayerOption
{
    Umbrella,
    WaterPump,
    Tent,
    Blanket
}

public enum NightType
{
    Rainy,
    Fire,
    Windy,
    Cold
}

public static class GameRules
{
    private static readonly IReadOnlyDictionary<PlayerOption, NightType> WinningNightByOption =
        new Dictionary<PlayerOption, NightType>
        {
            [PlayerOption.Umbrella] = NightType.Rainy,
            [PlayerOption.WaterPump] = NightType.Fire,
            [PlayerOption.Tent] = NightType.Windy,
            [PlayerOption.Blanket] = NightType.Cold
        };

    public static bool IsCorrect(PlayerOption option, NightType night)
    {
        return WinningNightByOption.TryGetValue(option, out var expectedNight) && expectedNight == night;
    }
}
