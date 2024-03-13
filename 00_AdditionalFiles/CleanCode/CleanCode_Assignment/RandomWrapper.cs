namespace CleanCode_Assignment;

public class RandomWrapper : IRandomNumber
{
    private readonly Random _random = new();

    public int Next(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }

    public int Next(int maxValue)
    {
        return _random.Next(maxValue);
    }
}