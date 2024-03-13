using System.Diagnostics.Metrics;
using System.Numerics;

namespace DiceGame.Game
{
    internal class GameEngine
    {
        private readonly Dice _dice;
        private readonly Player _player;

        public GameEngine(Dice dice, Player player)
        {
            this._dice = dice;
            this._player = player;
        }

        public string Start()
        {
            Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter number:");
                var quess = _player.GuessDiceNumber();

                if (quess == _dice.DiceNumber)
                {
                    return "You win!";
                }

                Console.WriteLine("Wrong number!");
            }

            return $"You lose! The correct number was {this._dice.DiceNumber}";
        }
    } 
}
