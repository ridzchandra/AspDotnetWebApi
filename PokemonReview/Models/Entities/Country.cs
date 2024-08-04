namespace PokemonReview.Models.Entities;

public class Country : BaseEntity
{
  public virtual ICollection<Owner> Owners { get; set; } = new HashSet<Owner>();

  // Private parameterless constructor for EF Core
  private Country()
  {
  }

  // Public constructor for application code
  public Country(string name) : base(name)
  {
  }
}
