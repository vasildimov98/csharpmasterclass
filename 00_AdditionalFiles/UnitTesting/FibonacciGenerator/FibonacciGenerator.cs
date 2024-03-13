using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("FibonacciGeneratorTests")] 

namespace FibonacciGenerator;

internal static class Fibonacci
{
    public static IEnumerable<int> Generate(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException(
                $"{nameof(n)} cannot be smaller than 0.");
        }

        const int MaxValidNumber = 46;
        if (n > MaxValidNumber)
        {
            throw new ArgumentException(
                $"{nameof(n)} cannot be larger than {MaxValidNumber}, " +
                $"as it will cause numeric overflow.");
        }

        var result = new List<int>();

        int previous = -1;
        int current = 1;
        for (int i = 0; i < n; i++)
        {
            int sum = previous + current;
            result.Add(sum);
            previous = current;
            current = sum;
        }

        return result;
    }
}