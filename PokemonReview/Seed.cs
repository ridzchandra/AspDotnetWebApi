using PokemonReview.Data;
using PokemonReview.Models;

namespace PokemonReview;

public class Seed(ApiDBContext context)
{
  private readonly ApiDBContext _apiDBContext = context;

  public void SeedApiDBContext()
  {
    if (!_apiDBContext.Pokemons.Any())
    {
      // seed pokemons
      var pikachu = new Pokemon("Pikachu") { BirthDate = new DateTime(1903, 1, 1, 0, 0, 0, DateTimeKind.Utc) };
      var squirtle = new Pokemon("Squirtle") { BirthDate = new DateTime(1903, 1, 1, 0, 0, 0, DateTimeKind.Utc) };
      var venasuar = new Pokemon("Venasuar") { BirthDate = new DateTime(1903, 1, 1, 0, 0, 0, DateTimeKind.Utc) };

      // seed owners
      var jack = new Owner("Jack")
      {
        Gym = "Brocks Gym",
        Country = new Country("Kanto")
      };
      var harry = new Owner("Harry")
      {
        Gym = "Mistys Gym",
        Country = new Country("Saffron City")
      };
      var ash = new Owner("Ash")
      {
        Gym = "Ash's Gym",
        Country = new Country("Millet Town")
      };

      // seed pokemon categories
      pikachu.Categories.Add(new Category("Electric"));
      squirtle.Categories.Add(new Category("Water"));
      venasuar.Categories.Add(new Category("Leaf"));

      // seed pokemon owners
      pikachu.Owners.Add(jack);
      squirtle.Owners.Add(harry);
      venasuar.Owners.Add(ash);

      // seed pokemon reviews
      pikachu.Reviews.Add(new Review("Pikachu")
      {
        Text = "Pikachu is the best pokemon, because it is electric.",
        Reviewer = new Reviewer("Teddy")
      });
      pikachu.Reviews.Add(new Review("Pikachu")
      {
        Text = "Pikachu is the best at killing rocks",
        Reviewer = new Reviewer("Taylor")
      });
      pikachu.Reviews.Add(new Review("Pikachu")
      {
        Text = "Pikachu, pickachu, pikachu",
        Reviewer = new Reviewer("Jessica")
      });

      squirtle.Reviews.Add(new Review("Squirtle")
      {
        Text = "Squirtle is the best pokemon, because it is electric.",
        Reviewer = new Reviewer("Teddy")
      });
      squirtle.Reviews.Add(new Review("Squirtle")
      {
        Text = "Squirtle is the best at killing rocks",
        Reviewer = new Reviewer("Taylor")
      });
      squirtle.Reviews.Add(new Review("Squirtle")
      {
        Text = "Squirtle, squirtle, squirtle",
        Reviewer = new Reviewer("Jessica")
      });

      venasuar.Reviews.Add(new Review("Venasuar")
      {
        Text = "Venasuar is the best pokemon, because it is electric.",
        Reviewer = new Reviewer("Teddy")
      });
      venasuar.Reviews.Add(new Review("Venasuar")
      {
        Text = "Venasuar is the best at killing rocks",
        Reviewer = new Reviewer("Taylor")
      });
      venasuar.Reviews.Add(new Review("Venasuar")
      {
        Text = "Venasuar, venasuar, venasuar",
        Reviewer = new Reviewer("Jessica")
      });

      _apiDBContext.Pokemons.AddRange(pikachu, squirtle, venasuar);
      _apiDBContext.SaveChanges();
    }
  }
}