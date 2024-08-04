namespace PokemonReview.Models.Entities;

public class Category : BaseEntity
{
  public virtual ICollection<Pokemon> Pokemons { get; set; } = new HashSet<Pokemon>();

  // Private parameterless constructor for EF Core// Parameterless constructor 
  private Category()
  {
  }

  // Public constructor for application code
  public Category(string name) : base(name)
  {
  }
}
