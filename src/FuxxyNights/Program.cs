using FuxxyNights;

var random = new Random();
var session = new GameSession(() => NextNight(random));

Console.WriteLine("Welcome to FuxxyNights!");
Console.WriteLine("Survive 10 nights by choosing the right item.");
Console.WriteLine();

session.Play(PromptForOption, Console.WriteLine);

static PlayerOption PromptForOption(int roundNumber)
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine($"Round {roundNumber}/{GameSession.DefaultRoundCount}");
        Console.WriteLine("Choose your defense:");
        Console.WriteLine("1) Umbrella -> beats rainy night");
        Console.WriteLine("2) Water pump -> beats fire night");
        Console.WriteLine("3) Tent -> beats windy night");
        Console.WriteLine("4) Blanket -> beats cold night");
        Console.Write("Your choice (1-4): ");

        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                return PlayerOption.Umbrella;
            case "2":
                return PlayerOption.WaterPump;
            case "3":
                return PlayerOption.Tent;
            case "4":
                return PlayerOption.Blanket;
            default:
                Console.WriteLine("Invalid choice. Enter a number from 1 to 4.");
                break;
        }
    }
}

static NightType NextNight(Random random)
{
    var nights = Enum.GetValues<NightType>();
    return nights[random.Next(nights.Length)];
}
