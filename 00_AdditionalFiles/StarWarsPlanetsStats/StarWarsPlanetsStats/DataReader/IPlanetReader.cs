using StarWarsPlanetsStats.Models;

namespace StarWarsPlanetsStats.DataReader
{
    public interface IPlanetReader
    {
        public Task<IEnumerable<Planet>> Read();
    }
}