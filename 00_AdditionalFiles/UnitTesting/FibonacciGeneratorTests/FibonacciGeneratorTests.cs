using FibonacciGenerator;
using NUnit.Framework;

namespace FibonacciGeneratorTests;

[TestFixture]
public class FibonacciGeneratorTests
{
    [TestCase(1, 0)]
    [TestCase(2, 1)]
    [TestCase(3, 1)]
    [TestCase(4, 2)]
    [TestCase(5, 3)]
    [TestCase(6, 5)]
    [TestCase(7, 8)]
    [TestCase(8, 13)]
    [TestCase(9, 21)]
    [TestCase(10, 34)]
    public void Generate_ShouldReturnCollectionWithExpectedLastNumber_IfNIsValid(int n, int expectedLastNumber)
    {
        var result = Fibonacci.Generate(n);

        Assert.AreEqual(expectedLastNumber, result.Last());
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(10)]
    public void Generate_ShouldReturnExactLengthEqualToN_IfNIsValid(int n)
    {
        var result = Fibonacci.Generate(n);

        Assert.AreEqual(n, result.Count());
    }

    [Test]
    public void Generate_ShouldReturnLargeCollection_IfNIsTheMaximumValidNumber()
    {
        var maxValidNumber = 46;

        var result = Fibonacci.Generate(maxValidNumber);

        Assert.AreEqual(maxValidNumber, result.Count());
    }

    [Test]
    public void Generate_ShouldReturnEmptyCollection_IfNIsZero()
    {
        var result = Fibonacci.Generate(0);

        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void Generate_ShouldThrowArgumentException_IfNIsLargerThan46()
    {
        Assert
            .Throws<ArgumentException>(
                () => Fibonacci.Generate(47),
                $"n cannot be larger than 46, as it will cause numeric overflow.");
    }

    [Test]
    public void Generate_ShouldThrowArgumentException_IfNIsLessThanZerro()
    {
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(-1), "n cannot be smaller than 0.");
    }
}
