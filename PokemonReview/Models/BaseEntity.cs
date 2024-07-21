using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models
{
  public class BaseEntity
  {
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    // Parameterless constructor
    public BaseEntity()
    {
    }

    // Constructor overload with 'name' parameter
    public BaseEntity(string name)
    {
      Name = name;
    }
  }
}
