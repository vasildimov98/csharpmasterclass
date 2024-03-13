using StarWarsPlanetsStats.DTOs;
using StarWarsPlanetsStats.Models;
using System.Text.Json;

namespace StarWarsPlanetsStats.DataReader
{
    public class PlanetFromApiReader(IStarWarsApi starWarsApi) : IPlanetReader
    {
        private readonly IStarWarsApi _starWarsApi = starWarsApi;

        public async Task<IEnumerable<Planet>> Read()
        {
            var json = await _starWarsApi.GetPlanetJson();

            var results = JsonSerializer.Deserialize<StarWarsDTOs>(json);

            if (results == null)
            {
                throw new ArgumentNullException(nameof(results));
            }

            return ToPlanets(results.Results);
        }

        private static IEnumerable<Planet> ToPlanets(IEnumerable<PlanetsDTO> planetsDTOs)
        {
            return planetsDTOs.Select(p => (Planet)p);
        }
    }
}