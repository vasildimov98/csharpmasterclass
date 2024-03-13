using StarWarsPlanetsStats.Models;
using StarWarsPlanetsStats.User;

namespace StarWarsPlanetsStats.App
{
    public class StarWarsPlanetAnalyzer(IUserInteraction userInteraction) : IStarWarsPlanetAnalyzer
    {
        private readonly IUserInteraction _userInteraction = userInteraction;
        private readonly Dictionary<string, Func<Planet, long?>> _validChoice = new()
        {
            ["population"] = p => p.Population,
            ["diameter"] = p => p.Diameter,
            ["surface water"] = p => p.SurfaceWater,
        };

        public void Analyze(IEnumerable<Planet> planets)
        {
            _userInteraction.PrompUserToChose();

            var choice = _userInteraction.GetUserChoice();

            _userInteraction.ShowPlanetRecords(planets.MaxBy(_validChoice[choice]), "Max", choice, _validChoice[choice]);
            _userInteraction.ShowPlanetRecords(planets.MinBy(_validChoice[choice]), "Min", choice, _validChoice[choice]);
        }
    }
}