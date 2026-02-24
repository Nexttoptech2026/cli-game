using FuxxyNights;

namespace Unit.Tests;

public class RoundScoringTests
{
    [Fact]
    public void Evaluate_returns_10_points_when_guess_is_correct()
    {
        var result = RoundScoring.Evaluate(PlayerOption.Umbrella, NightType.Rainy);
        Assert.Equal(10, result.Points);
    }

    [Fact]
    public void Evaluate_returns_0_points_when_guess_is_wrong()
    {
        var result = RoundScoring.Evaluate(PlayerOption.Umbrella, NightType.Fire);
        Assert.Equal(0, result.Points);
    }

    [Fact]
    public void CalculateTotalScore_sums_points_from_all_rounds()
    {
        var rounds = new[]
        {
            RoundScoring.Evaluate(PlayerOption.Umbrella, NightType.Rainy),
            RoundScoring.Evaluate(PlayerOption.Tent, NightType.Fire),
            RoundScoring.Evaluate(PlayerOption.Blanket, NightType.Cold)
        };

        var totalScore = RoundScoring.CalculateTotalScore(rounds);

        Assert.Equal(20, totalScore);
    }
}
