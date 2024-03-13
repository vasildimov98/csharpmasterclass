using System.Text.Json.Serialization;

namespace StarWarsPlanetsStats.DTOs
{
    public record PlanetsDTO(
           [property: JsonPropertyName("name")] string Name,
           [property: JsonPropertyName("diameter")] string Diameter,
           [property: JsonPropertyName("surface_water")] string SurfaceWater,
           [property: JsonPropertyName("population")] string Population
    );
}