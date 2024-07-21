using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models;

public class Reviewer(string firstName)
{
  // You don't have to make Id [Required] because you don't need this from the HTTP request
  // It's auto generated in the database
  public int Id { get; set; }
  [Required]
  public string FirstName { get; set; } = firstName;
  public string? LastName { get; set; }
  public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

}
