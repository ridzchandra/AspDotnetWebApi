namespace PokemonReview.Models;

public class Pokemon(string name) : BaseEntity(name)
{
  public DateTime? BirthDate { get; set; } = null;
  public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
  public virtual ICollection<Owner> Owners { get; set; } = new HashSet<Owner>();
  public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

}
