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
        ArgumentNullException.ThrowIfNull(nextNight);
        _nextNight = nextNight;
    }

    public GameSummary Play(Func<int, PlayerOption> getPlayerOption, Action<string> writeLine)
    {
        ArgumentNullException.ThrowIfNull(getPlayerOption);
        ArgumentNullException.ThrowIfNull(writeLine);

        var rounds = new List<RoundResult>(DefaultRoundCount);

        for (var roundIndex = 0; roundIndex < DefaultRoundCount; roundIndex++)
        {
            var roundNumber = roundIndex + 1;
            var option = getPlayerOption(roundNumber);
            var night = _nextNight();
            var round = RoundScoring.Evaluate(option, night);

            rounds.Add(round);
            writeLine($"Round {roundNumber}: night was {night}, you picked {option}, score +{round.Points}");
        }

        var finalScore = RoundScoring.CalculateTotalScore(rounds);
        writeLine($"Final score: {finalScore}");

        return new GameSummary(DefaultRoundCount, finalScore, rounds);
    }
}
