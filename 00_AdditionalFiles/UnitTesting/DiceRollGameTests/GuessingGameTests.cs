using Game;
using Moq;
using NUnit.Framework;
using UserCommunication;

namespace DiceRollGameTests;

# nullable disable
[TestFixture]
public class GuessingGameTests
{
    private GuessingGame _cut;
    private Mock<IDice> _dice;
    private Mock<IUserCommunication> _userCommunication;

    [SetUp]
    public void SetUp()
    {
        _dice = new Mock<IDice>();
        _userCommunication = new Mock<IUserCommunication>();

        _cut = new GuessingGame(_dice.Object, _userCommunication.Object);
    }

    [Test]
    public void Play_ShouldReturnVictory_IfUserGuessTheNumberCorrectly()
    {
        _dice.Setup(d => d.Roll()).Returns(1);
        _userCommunication.Setup(uc => uc.ReadInteger("Enter a number:")).Returns(1);

        var actualResult = _cut.Play();

        _userCommunication
            .Verify(uc => uc
                .ShowMessage($"Dice rolled. Guess what number it shows in 3 tries."), Times.Exactly(1));
        Assert.That(actualResult, Is.EqualTo(GameResult.Victory));
    }

    [Test]
    public void Play_ShouldReturnVictory_EvenIfUserGuessItOnThirdTry()
    {
        _dice.Setup(d => d.Roll()).Returns(1);
        _userCommunication
            .SetupSequence(uc => uc
                .ReadInteger("Enter a number:"))
            .Returns(2)
            .Returns(5)
            .Returns(1);

        var actualResult = _cut.Play();

        _userCommunication
            .Verify(uc => uc
            .ShowMessage($"Dice rolled. Guess what number it shows in 3 tries."), Times.Exactly(1));
        _userCommunication
            .Verify(uc => uc
                .ShowMessage("Wrong number."), Times.Exactly(2));
        Assert.That(actualResult, Is.EqualTo(GameResult.Victory));
    }

    [Test]
    public void Play_ShouldReturnLoss_IfUserDidNotGuessTheNumberForThreeRounds()
    {
        _dice.Setup(d => d.Roll()).Returns(1);
        _userCommunication
            .SetupSequence(uc => uc
                .ReadInteger("Enter a number:"))
            .Returns(2)
            .Returns(5)
            .Returns(6);

        var actualResult = _cut.Play();

        _userCommunication
            .Verify(uc => uc
            .ShowMessage($"Dice rolled. Guess what number it shows in 3 tries."), Times.Exactly(1));
        _userCommunication
            .Verify(uc => uc
                .ShowMessage("Wrong number."), Times.Exactly(3));
        Assert.That(actualResult, Is.EqualTo(GameResult.Loss));
    }

    [TestCase(new int[] {7, 8, 1}, GameResult.Victory)]
    [TestCase(new int[] {7, 8, 9}, GameResult.Loss)]
    public void Play_ShouldNotStop_IfUserGuessesValidNumberBiggerThan6(int[] guess, GameResult gameResult)
    {
        _dice.Setup(d => d.Roll()).Returns(1);
        _userCommunication
            .SetupSequence(uc => uc
                .ReadInteger("Enter a number:"))
            .Returns(guess[0])
            .Returns(guess[1])
            .Returns(guess[2]);

        var actualResult = _cut.Play();

        _userCommunication
            .Verify(uc => uc
            .ShowMessage($"Dice rolled. Guess what number it shows in 3 tries."), Times.Exactly(1));
        _userCommunication
            .Verify(uc => uc
                .ShowMessage("Wrong number."), Times.AtLeast(2));
        Assert.That(actualResult, Is.EqualTo(gameResult));
    }
}
