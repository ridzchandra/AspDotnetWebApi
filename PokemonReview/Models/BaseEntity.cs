using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models;

public class BaseEntity(string name)
{
  // You don't have to make Id [Required] because you don't need this from the HTTP request
  // It's auto generated in the database
  public int Id { get; set; }
  [Required]
  public string Name { get; set; } = name;
}
