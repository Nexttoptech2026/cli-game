using FuxxyNights;

namespace Unit.Tests;

public class GameSessionTests
{
    [Fact]
    public void Play_runs_exactly_10_rounds()
    {
        var generator = new SequenceNightGenerator(Enumerable.Repeat(NightType.Rainy, 10));
        var session = new GameSession(generator.NextNight);

        var summary = session.Play(_ => PlayerOption.Umbrella, _ => { });

        Assert.Equal(10, summary.TotalRounds);
        Assert.Equal(10, summary.Rounds.Count);
    }

    [Fact]
    public void Play_max_score_is_100_when_all_guesses_are_correct()
    {
        var generator = new SequenceNightGenerator(Enumerable.Repeat(NightType.Rainy, 10));
        var session = new GameSession(generator.NextNight);

        var summary = session.Play(_ => PlayerOption.Umbrella, _ => { });

        Assert.Equal(100, summary.FinalScore);
    }

    [Fact]
    public void Play_writes_final_score_at_the_end()
    {
        var messages = new List<string>();
        var generator = new SequenceNightGenerator(Enumerable.Repeat(NightType.Rainy, 10));
        var session = new GameSession(generator.NextNight);

        session.Play(_ => PlayerOption.Umbrella, messages.Add);

        Assert.Equal("Final score: 100", messages.Last());
    }

    [Fact]
    public void Play_uses_injected_night_generator_once_per_round()
    {
        var nights = new[]
        {
            NightType.Rainy, NightType.Fire, NightType.Windy, NightType.Cold,
            NightType.Rainy, NightType.Fire, NightType.Windy, NightType.Cold,
            NightType.Rainy, NightType.Fire
        };

        var generator = new SequenceNightGenerator(nights);
        var session = new GameSession(generator.NextNight);

        session.Play(_ => PlayerOption.Umbrella, _ => { });

        Assert.Equal(10, generator.CallCount);
    }

    private sealed class SequenceNightGenerator
    {
        private readonly Queue<NightType> _nights;

        public SequenceNightGenerator(IEnumerable<NightType> nights)
        {
            _nights = new Queue<NightType>(nights);
        }

        public int CallCount { get; private set; }

        public NightType NextNight()
        {
            CallCount++;

            if (_nights.TryDequeue(out var night))
            {
                return night;
            }

            return NightType.Rainy;
        }
    }
}
