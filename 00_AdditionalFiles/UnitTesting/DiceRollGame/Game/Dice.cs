namespace Game;

public class Dice(Random random) : IDice
{
    private readonly Random _random = random;
    private const int SidesCount = 6;

    public int Roll() => _random.Next(1, SidesCount + 1);
}