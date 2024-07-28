using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.DataAccess.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Controllers;

// [controller] is a placeholder for the name of the controller class without the Controller suffix
// In this case, [controller] is Pokemon
// The route for this controller is api/Pokemon = controller level routing
[Route("api/[controller]")]
[ApiController]
public class PokemonController(IUnitOfWork unitOfWork) : ControllerBase
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;


  // Action Method to get all Pokemons
  [HttpGet]
  public async Task<IActionResult> GetPokemons([FromQuery] short page, [FromQuery] short pageSize, [FromQuery] string gym)
  {
    ArgumentOutOfRangeException.ThrowIfLessThan(page, 1, nameof(page));
    ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1, nameof(pageSize));

    if (!string.IsNullOrWhiteSpace(gym))
    {
      var pokemonsFromGym = await _unitOfWork.Pokemons.GetPokemonsWithOwnersFromGym(page, pageSize, gym);
      await _unitOfWork.CompleteAsync();
      return pokemonsFromGym.Any() ? Ok(pokemonsFromGym) : NotFound();
    }

    // var pokemons = _pokemonRepo.GetPokemons(page, pageSize);
    var pokemons = await _unitOfWork.Pokemons.GetAllAsync(page, pageSize);
    await _unitOfWork.CompleteAsync();
    return pokemons.Any() ? Ok(pokemons) : NotFound();
  }

  // Action Method to get a Pokemon by Id
  // The route for this action method is api/Pokemon/{id} - action method level routing
  // {} is the notation for a path parameter.
  // Without {} the route would be just the string appended to the controller route in this case api/Pokemon/id
  [HttpGet("{id}")]
  public async Task<IActionResult> GetPokemon(int id)
  {
    var pokemon = await _unitOfWork.Pokemons.GetByIdAsync(id);
    await _unitOfWork.CompleteAsync();
    return pokemon != null ? Ok(pokemon) : NotFound();
  }

  [HttpPost]
  public async Task<IActionResult> AddPokemons([FromBody] Pokemon[] pokemons)
  {
    await _unitOfWork.Pokemons.AddRangeAsync(pokemons);
    await _unitOfWork.CompleteAsync();
    return NoContent();
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdatePokemon(int id, JsonPatchDocument<Pokemon> pokemonUpdates)
  {
    var pokemon = await _unitOfWork.Pokemons.GetByIdAsync(id);
    if (pokemon == null)
    {
      return NotFound();
    }

    pokemonUpdates.ApplyTo(pokemon);
    await _unitOfWork.CompleteAsync();
    return NoContent();
  }
}
