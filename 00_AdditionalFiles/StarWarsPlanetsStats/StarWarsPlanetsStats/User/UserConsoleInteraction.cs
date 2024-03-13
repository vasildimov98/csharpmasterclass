using StarWarsPlanetsStats.Models;

namespace StarWarsPlanetsStats.User
{
    public class UserConsoleInteraction(ITablePrinter tablePrinter) : IUserInteraction
    {
        private readonly ITablePrinter _tablePrinter = tablePrinter;

        public void Exit()
        {
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }

        public string GetUserChoice()
        {
            do
            {
                var userChoice = Console.ReadLine();

                if (userChoice is not null)
                {
                    userChoice = userChoice.ToLower();
                }

                switch (userChoice)
                {
                    case "population":
                        return userChoice;
                    case "diameter":
                        return userChoice;
                    case "surface water":
                        return userChoice;
                    default:
                        ShowMessage("Invalid choice");
                        break;
                }
            } while (true);
        }

        public void PrompUserToChose()
        {
            ShowMessage(
    @"The statistics of which property would you like to see?
population
diameter
surface water");
            ShowNewLine();
        }

        public void Show<T>(IEnumerable<T> items)
        {
            _tablePrinter.Print(items);
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowPlanetRecords(Planet planet, string meter, string parameter, Func<Planet, long?> func)
        {
            ShowMessage($"{meter} {parameter} is {func(planet)} (planet: {planet.Name})");
        }

        private static void ShowNewLine() { Console.WriteLine(); }
    }
}