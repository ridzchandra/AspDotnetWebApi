namespace PokemonReview.Models
{
  public class Country : BaseEntity
  {
    public virtual ICollection<Owner> Owners { get; set; } = new HashSet<Owner>();

    // Parameterless constructor
    public Country()
    {
    }

    // Constructor overload with 'name' parameter
    public Country(string name) : base(name)
    {
    }
  }
}
