using System.Text.Json.Serialization;

namespace StarWarsPlanetsStats.DTOs
{
    public record StarWarsDTOs(
        [property: JsonPropertyName("results")] IReadOnlyList<PlanetsDTO> Results
    );
}