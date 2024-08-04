using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models.Entities;

public class Reviewer
{
  public int Id { get; set; }

  [Required]
  public string FirstName { get; set; } = null!;

  public string? LastName { get; set; }
  public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

  // Private parameterless constructor for EF Core
  private Reviewer()
  {
  }

  // Public constructor for application code
  public Reviewer(string firstName)
  {
    FirstName = firstName;
  }
}
