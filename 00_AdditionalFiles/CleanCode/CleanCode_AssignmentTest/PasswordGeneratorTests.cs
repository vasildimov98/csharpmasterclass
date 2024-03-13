using CleanCode_Assignment;
using Moq;
using NUnit.Framework;

namespace CleanCode_AssignmentTest;

[TestFixture]
public class PasswordGeneratorTests
{
    private PasswordGenerator? _cut;
    private Mock<IRandomNumber>? _randomMock;

    [SetUp]
    public void SetUp()
    {
        this._randomMock = new Mock<IRandomNumber>();
        this._cut = new PasswordGenerator(this._randomMock.Object);
    }

    [Test]
    public void Generate_ShouldThrowException_IfMinValueIsLessThan1()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this._cut!.Generate(0, 1, false));
    }

    [Test]
    public void Generate_ShouldThrowException_IfMinValueIsGreaterThanMaxValue()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this._cut!.Generate(12, 2, false));
    }

    [Test]
    public void Generate_ShouldCreatePasswordWithoutSpecialCharaters_IfShallUseSpecialCaracterIsFalse()
    {
        var charactesToUse = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var minLength = 1;
        var maxLength = 10;
        var passwordLength = 5;
        var shallUseSpecialCharacter = false;
        var expectedPassword = $"{charactesToUse[0]}{charactesToUse[2]}{charactesToUse[5]}{charactesToUse[6]}{charactesToUse[^1]}";
        this._randomMock!
            .Setup(random => random.Next(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(passwordLength);
        this._randomMock
            .SetupSequence(random => random.Next(It.IsAny<int>()))
            .Returns(0)
            .Returns(2)
            .Returns(5)
            .Returns(6)
            .Returns(charactesToUse.Length - 1);


        var password = this._cut!.Generate(minLength, maxLength, shallUseSpecialCharacter);

        Assert.That(password, Is.EqualTo(expectedPassword));
    }

    [Test]
    public void Generate_ShouldCreatePasswordWithSpecialCharaters_IfShallUseSpecialCaracterIsTrue()
    {
        var charactesToUse = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=";
        var minLength = 1;
        var maxLength = 10;
        var passwordLength = 5;
        var shallUseSpecialCharacter = true;
        var expectedPassword = $"{charactesToUse[0]}{charactesToUse[2]}{charactesToUse[^5]}{charactesToUse[^4]}{charactesToUse[^1]}";
        this._randomMock!
            .Setup(random => random.Next(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(passwordLength);
        this._randomMock
            .SetupSequence(random => random.Next(It.IsAny<int>()))
            .Returns(0)
            .Returns(2)
            .Returns(charactesToUse.Length - 5)
            .Returns(charactesToUse.Length - 4)
            .Returns(charactesToUse.Length - 1);


        var password = this._cut!.Generate(minLength, maxLength, shallUseSpecialCharacter);

        Assert.That(password, Is.EqualTo(expectedPassword));
    }
}
