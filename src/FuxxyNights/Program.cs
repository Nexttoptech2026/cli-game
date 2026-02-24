using FuxxyNights;

var random = new Random();
var session = new GameSession(() => NextNight(random));

Console.WriteLine("Welcome to FuxxyNights!");
Console.WriteLine("Survive 10 nights by choosing the right item.");
Console.WriteLine("You can type a number (1-4) or the item name.");
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
        Console.Write("Your choice: ");

        var input = Console.ReadLine();

        if (PlayerOptionParser.TryParse(input, out var option))
        {
            return option;
        }

        Console.WriteLine("Invalid choice. Enter 1-4 or item name (umbrella, water pump, tent, blanket).");
    }
}

static NightType NextNight(Random random)
{
    var nights = Enum.GetValues<NightType>();
    return nights[random.Next(nights.Length)];
}
