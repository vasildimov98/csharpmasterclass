namespace StarWarsPlanetsStats.DataAccess
{
    public class StarWarsApi(HttpClient httpClient) : IStarWarsApi
    {
        private const string BASE_URL = "https://swapi.dev/api/";
        private const string PLANETS_END_POINT = "planets";

        private readonly HttpClient _httpClient = httpClient;

        public async Task<string> GetPlanetJson()
        {
            _httpClient.BaseAddress = new Uri(BASE_URL);
            var response = await _httpClient.GetAsync(PLANETS_END_POINT);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}