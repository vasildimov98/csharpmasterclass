using DiceGame.Game;

namespace DiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dice = new Dice();
            var player = new Player();
            
            var gameEngine = new GameEngine(dice, player);

            var result = gameEngine.Start();

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
