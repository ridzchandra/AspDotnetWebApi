namespace PokemonReview.Models;

public class Category : BaseEntity
{
  public virtual ICollection<Pokemon> Pokemons { get; set; } = new HashSet<Pokemon>();

  // Parameterless constructor
  public Category()
  {
  }

  // Constructor overload with 'name' parameter
  public Category(string name) : base(name)
  {
  }
}
