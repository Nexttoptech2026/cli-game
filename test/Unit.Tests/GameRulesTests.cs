using FuxxyNights;

namespace Unit.Tests;

public class GameRulesTests
{
    [Theory]
    [InlineData(PlayerOption.Umbrella, NightType.Rainy)]
    [InlineData(PlayerOption.WaterPump, NightType.Fire)]
    [InlineData(PlayerOption.Tent, NightType.Windy)]
    [InlineData(PlayerOption.Blanket, NightType.Cold)]
    public void IsCorrect_returns_true_for_winning_pairs(PlayerOption option, NightType night)
    {
        var result = GameRules.IsCorrect(option, night);
        Assert.True(result);
    }

    [Fact]
    public void IsCorrect_returns_false_for_all_other_pairs()
    {
        var winningPairs = new HashSet<(PlayerOption Option, NightType Night)>
        {
            (PlayerOption.Umbrella, NightType.Rainy),
            (PlayerOption.WaterPump, NightType.Fire),
            (PlayerOption.Tent, NightType.Windy),
            (PlayerOption.Blanket, NightType.Cold)
        };

        foreach (var option in Enum.GetValues<PlayerOption>())
        {
            foreach (var night in Enum.GetValues<NightType>())
            {
                if (winningPairs.Contains((option, night)))
                {
                    continue;
                }

                var result = GameRules.IsCorrect(option, night);
                Assert.False(result);
            }
        }
    }
}
