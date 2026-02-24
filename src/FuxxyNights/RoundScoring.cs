namespace FuxxyNights;

public sealed record RoundResult(
    PlayerOption Option,
    NightType Night,
    bool IsCorrect,
    int Points);

public static class RoundScoring
{
    public static RoundResult Evaluate(PlayerOption option, NightType night)
    {
        throw new NotImplementedException();
    }

    public static int CalculateTotalScore(IEnumerable<RoundResult> rounds)
    {
        throw new NotImplementedException();
    }
}
