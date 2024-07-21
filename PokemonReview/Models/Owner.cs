namespace PokemonReview.Models;

public class Owner : BaseEntity
{
  public string? Gym { get; set; }
  public virtual Country? Country { get; set; }
  public virtual ICollection<Pokemon> Pokemons { get; set; } = new HashSet<Pokemon>();

  // Parameterless constructor
  public Owner()
  {
  }

  // Constructor overload with 'name' parameter
  public Owner(string name) : base(name)
  {
  }
}
