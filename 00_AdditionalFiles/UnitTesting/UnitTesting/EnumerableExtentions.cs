namespace UnitTesting;

public static class EnumerableExtentions
{
    public static int CalculateSumOfEven(this IEnumerable<int> ints)
    {
        return ints.Where(x => x % 2 == 0).Sum();
    }
}
