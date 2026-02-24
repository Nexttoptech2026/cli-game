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
        var isCorrect = GameRules.IsCorrect(option, night);
        var points = isCorrect ? 10 : 0;

        return new RoundResult(option, night, isCorrect, points);
    }

    public static int CalculateTotalScore(IEnumerable<RoundResult> rounds)
    {
        return rounds.Sum(x => x.Points);
    }
}
