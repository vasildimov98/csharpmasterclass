using StarWarsPlanetsStats.Models;

namespace StarWarsPlanetsStats.App
{
    public interface IStarWarsPlanetAnalyzer
    {
        void Analyze(IEnumerable<Planet> planets);
    }
}