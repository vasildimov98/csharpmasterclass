using StarWarsPlanetsStats.DataReader;
using StarWarsPlanetsStats.User;

namespace StarWarsPlanetsStats.App
{
    public class StarWarsPlanetEngine(IPlanetReader planetReader,
        IStarWarsPlanetAnalyzer starWarsPlanetAnalyzer,
        IUserInteraction userInteraction)
    {
        private readonly IPlanetReader _planetReader = planetReader;
        private readonly IStarWarsPlanetAnalyzer _starWarsPlanetAnalyzer = starWarsPlanetAnalyzer;
        private readonly IUserInteraction _userInteraction = userInteraction;

        public async Task Start()
        {
            var planets = await this._planetReader.Read();

            this._userInteraction.Show(planets);

            _starWarsPlanetAnalyzer.Analyze(planets);

            this._userInteraction.Exit();
        }
    }

}
