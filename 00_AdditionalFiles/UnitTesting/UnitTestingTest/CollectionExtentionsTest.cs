using NUnit.Framework;
using UnitTesting;

namespace UnitTestingTest;

[TestFixture]
public class CollectionExtentionsTest
{
    [Test]
    public void CalculateSumOfEven_ShouldReturnZero_IfEmptyCollection()
    {
        var emptyCollection = Enumerable.Empty<int>();

        var sumOfEven = emptyCollection.CalculateSumOfEven();

        Assert.AreEqual(0, sumOfEven);
    }
}
