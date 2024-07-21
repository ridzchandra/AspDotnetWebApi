namespace PokemonReview.Models;

public class Pokemon : BaseEntity
{
  public DateTime? BirthDate { get; set; } = null;
  public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
  public virtual ICollection<Owner> Owners { get; set; } = new HashSet<Owner>();
  public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

  // Parameterless constructor
  public Pokemon()
  {
  }

  // Constructor overload with 'name' parameter
  public Pokemon(string name) : base(name)
  {
  }
}
