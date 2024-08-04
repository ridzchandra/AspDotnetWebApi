using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models.Entities;

public class Review
{
  public int Id { get; set; }

  [Required]
  public string Title { get; set; } = null!;

  [Required]
  public string Text { get; set; } = null!;

  public virtual Reviewer? Reviewer { get; set; }
  public virtual Pokemon? Pokemon { get; set; }

  // Private parameterless constructor for EF Core
  private Review()
  {
  }

  // Public constructor for application code
  public Review(string title)
  {
    Title = title;
  }
}
