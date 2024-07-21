using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models
{
  public class Review
  {
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Text { get; set; }

    public virtual Reviewer? Reviewer { get; set; }
    public virtual Pokemon? Pokemon { get; set; }

    // Parameterless constructor
    public Review()
    {
    }

    // Constructor overload with 'title' parameter
    public Review(string title)
    {
      Title = title;
    }
  }
}
