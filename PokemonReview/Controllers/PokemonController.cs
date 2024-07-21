using Microsoft.AspNetCore.Mvc;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Controllers;

// [controller] is a placeholder for the name of the controller class without the Controller suffix
// In this case, [controller] is Pokemon
// The route for this controller is api/Pokemon = controller level routing
[Route("api/[controller]")]
[ApiController]
public class PokemonController(IPokemonRepo pokemonRepo) : ControllerBase
{
  private readonly IPokemonRepo _pokemonRepo = pokemonRepo;


  // Action Method to get all Pokemons
  [HttpGet]
  public IActionResult GetPokemons([FromQuery] byte page, [FromQuery] byte pageSize)
  {
    var pokemons = _pokemonRepo.GetPokemons(page, pageSize);
    return pokemons.Count != 0 ? Ok(pokemons) : NotFound();
  }

  // Action Method to get a Pokemon by Id
  // The route for this action method is api/Pokemon/{id} - action method level routing
  // {} is the notation for a path parameter.
  // Without {} the route would be just the string appended to the controller route in this case api/Pokemon/id
  [HttpGet("{id}")]
  public IActionResult GetPokemon(int id)
  {
    var pokemon = _pokemonRepo.GetPokemon(id);
    return pokemon != null ? Ok(pokemon) : NotFound();
  }

  [HttpPost]
  public IActionResult AddPokemons([FromBody] Pokemon[] pokemons)
  {
    var ids = _pokemonRepo.AddPokemons(pokemons);
    return Ok(ids);
  }
}
