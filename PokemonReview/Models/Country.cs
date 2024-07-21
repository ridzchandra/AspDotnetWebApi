namespace PokemonReview.Models;

public class Country(string name) : BaseEntity(name)
{
  public virtual ICollection<Owner> Owners { get; set; } = new HashSet<Owner>();
}
