using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PokemonReview.Models.Entities
{
  public class BaseEntity
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    // Protected parameterless constructor for EF Core
    protected BaseEntity()
    {
    }

    // Public constructor for application code 
    public BaseEntity(string name)
    {
      Name = name;
    }
  }
}
