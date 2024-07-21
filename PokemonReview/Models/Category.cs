namespace PokemonReview.Models;

public class Category(string name) : BaseEntity(name)
{
  public virtual ICollection<Pokemon> Pokemons { get; set; } = new HashSet<Pokemon>();
}
