namespace PokemonReview.Models.Entities;

public class Pokemon : BaseEntity
{
  public DateTime? BirthDate { get; set; }
  public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
  public virtual ICollection<Owner> Owners { get; set; } = new HashSet<Owner>();
  public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

  // Private parameterless constructor for EF Core
  private Pokemon()
  {
  }

  // Public constructor for application code
  public Pokemon(string name) : base(name)
  {
  }
}
