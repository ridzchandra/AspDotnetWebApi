namespace PokemonReview.Models;

public class Owner(string name) : BaseEntity(name)
{
  public string? Gym { get; set; }
  public virtual Country? Country { get; set; }
  public virtual ICollection<Pokemon> Pokemons { get; set; } = new HashSet<Pokemon>();
}
