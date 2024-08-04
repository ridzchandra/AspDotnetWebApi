using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.DataAccess.Interfaces;
using PokemonReview.Models.Dtos.Responses;
using PokemonReview.Models.Entities;

namespace PokemonReview.Controllers;

// [controller] is a placeholder for the name of the controller class without the Controller suffix
// In this case, [controller] is Pokemon
// The route for this controller is api/Pokemon = controller level routing
[Route("api/[controller]")]
[ApiController]
public class PokemonController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMapper _mapper = mapper;


  // Action Method to get all Pokemons
  [HttpGet]
  public async Task<IActionResult> GetPokemons([FromQuery] short page, [FromQuery] short pageSize, [FromQuery] string? gym = null)
  {
    ArgumentOutOfRangeException.ThrowIfLessThan(page, 1, nameof(page));
    ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1, nameof(pageSize));

    if (!string.IsNullOrWhiteSpace(gym))
    {
      var pokemonsFromGym = await _unitOfWork.Pokemons.GetPokemonsWithOwnersFromGym(page, pageSize, gym);
      var pokemonDtosFromGym = _mapper.Map<IEnumerable<GetPokemonWithOwnerDto>>(pokemonsFromGym);
      await _unitOfWork.CompleteAsync();
      return pokemonDtosFromGym.Any() ? Ok(pokemonDtosFromGym) : NotFound();
    }

    // var pokemons = _pokemonRepo.GetPokemons(page, pageSize);
    var pokemons = await _unitOfWork.Pokemons.GetAllAsync(page, pageSize);
    var pokemonDtos = _mapper.Map<IEnumerable<GetPokemonDto>>(pokemons);
    await _unitOfWork.CompleteAsync();
    return pokemonDtos.Any() ? Ok(pokemonDtos) : NotFound();
  }

  // Action Method to get a Pokemon by Id
  // The route for this action method is api/Pokemon/{id} - action method level routing
  // {} is the notation for a path parameter.
  // Without {} the route would be just the string appended to the controller route in this case api/Pokemon/id
  [HttpGet("{id}")]
  public async Task<IActionResult> GetPokemon(int id)
  {
    var pokemon = await _unitOfWork.Pokemons.GetByIdAsync(id);
    var pokemonDto = _mapper.Map<GetPokemonDto>(pokemon);
    await _unitOfWork.CompleteAsync();
    return pokemonDto != null ? Ok(pokemonDto) : NotFound();
  }

  [HttpPost]
  public async Task<IActionResult> AddPokemons([FromBody] AddPokemonDto[] pokemonDtos)
  {
    var pokemons = _mapper.Map<IEnumerable<Pokemon>>(pokemonDtos);
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
