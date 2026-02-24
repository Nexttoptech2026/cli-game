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
    public static bool IsCorrect(PlayerOption option, NightType night)
    {
        return (option, night) switch
        {
            (PlayerOption.Umbrella, NightType.Rainy) => true,
            (PlayerOption.WaterPump, NightType.Fire) => true,
            (PlayerOption.Tent, NightType.Windy) => true,
            (PlayerOption.Blanket, NightType.Cold) => true,
            _ => false
        };
    }
}
