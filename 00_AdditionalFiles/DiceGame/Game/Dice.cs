namespace DiceGame.Game
{
    internal class Dice
    {
        public Dice()
        {
            this.DiceNumber = Random.Shared.Next(1, 7);
        }

        public int DiceNumber { get; private set; }
        
    }
}
