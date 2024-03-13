using StarWarsPlanetsStats.DTOs;

namespace StarWarsPlanetsStats.Models
{
    public readonly record struct Planet
    {
        public string Name { get; }
        public int Diameter { get; }
        public int? SurfaceWater { get; }
        public long? Population { get; }

        public Planet(string name, int diameter, int? surfaceWater, long? population)
        {
            ArgumentNullException.ThrowIfNull(name);

            Name = name;
            Diameter = diameter;
            SurfaceWater = surfaceWater;
            Population = population;
        }


        public static explicit operator Planet(PlanetsDTO planet)
        {
            var name = planet.Name;

            var diameter = int.Parse(planet.Diameter);

            long? population = null;
            if (long.TryParse(planet.Population, out var outPopulation))
            {
                population = outPopulation;
            }

            int? surfaceWater = null;
            if (int.TryParse(planet.SurfaceWater, out var outSurfaceWater))
            {
                surfaceWater = outSurfaceWater;
            }

            return new Planet(name, diameter, surfaceWater, population);
        }
    }
}