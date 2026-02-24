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
        throw new NotImplementedException();
    }
}
