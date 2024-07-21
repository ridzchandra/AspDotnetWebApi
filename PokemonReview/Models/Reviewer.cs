using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models;

public class Reviewer
{
  public int Id { get; set; }

  [Required]
  public string? FirstName { get; set; }

  public string? LastName { get; set; }
  public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

  // Parameterless constructor
  public Reviewer()
  {
  }

  // Constructor overload with 'firstName' parameter
  public Reviewer(string firstName)
  {
    FirstName = firstName;
  }
}
