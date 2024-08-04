namespace PokemonReview.Models.Dtos.Responses;

public record GetPokemonWithOwnerDto
{
  public required string Name { get; init; }
  public DateTime? BirthDate { get; init; }
  public IEnumerable<string>? OwnerNames { get; init; }
}
