using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models;

public class Review(string title)
{
  // You don't have to make Id [Required] because you don't need this from the HTTP request
  // It's auto generated in the database
  public int Id { get; set; }
  [Required]
  public string Title { get; set; } = title;
  [Required]
  public string? Text { get; set; }
  public virtual Reviewer? Reviewer { get; set; }
  public virtual Pokemon? Pokemon { get; set; }
}
