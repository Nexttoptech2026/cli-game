namespace FuxxyNights;

public sealed record GameSummary(
    int TotalRounds,
    int FinalScore,
    IReadOnlyList<RoundResult> Rounds);

public sealed class GameSession
{
    public const int DefaultRoundCount = 10;

    private readonly Func<NightType> _nextNight;

    public GameSession(Func<NightType> nextNight)
    {
        _nextNight = nextNight;
    }

    public GameSummary Play(Func<int, PlayerOption> getPlayerOption, Action<string> writeLine)
    {
        throw new NotImplementedException();
    }
}
