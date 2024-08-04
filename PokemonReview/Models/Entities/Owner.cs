using System.Diagnostics.CodeAnalysis;

namespace PokemonReview.Models.Entities;

public class Owner : BaseEntity
{
  public string? Gym { get; set; }
  public virtual Country? Country { get; set; }
  public virtual ICollection<Pokemon> Pokemons { get; set; } = new HashSet<Pokemon>();

  // Private parameterless constructor for EF Core
  private Owner()
  {
  }

  // Public constructor for application code
  public Owner(string name) : base(name)
  {
  }
}
