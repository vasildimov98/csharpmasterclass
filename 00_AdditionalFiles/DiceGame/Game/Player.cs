using DiceGame.Validators;

namespace DiceGame.Game
{
    internal class Player
    {
        public int GuessDiceNumber()
        {
            var choice = Console.ReadLine();

            while (!ChoiceValidator.IsValid(choice))
            {
                Console.WriteLine("Incorrect input");
               choice = Console.ReadLine();
            }


            return int.Parse(choice ?? "0");
        }

        public string Name { private get; set; }
        

    }


    
}
