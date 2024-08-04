namespace PokemonReview.Models.Dtos.Responses;

public record GetPokemonDto
{
  public required string Name { get; init; }
  public DateTime? BirthDate { get; init; }
}
