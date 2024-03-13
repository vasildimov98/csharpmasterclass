using StarWarsPlanetsStats.Models;

namespace StarWarsPlanetsStats.User
{
    public interface IUserInteraction
    {
        void ShowMessage(string message);

        string GetUserChoice();

        void Show<T>(IEnumerable<T> items);

        void PrompUserToChose();

        void Exit();
        void ShowPlanetRecords(Planet planet, string meter, string parameter, Func<Planet, long?> func);
    }
}