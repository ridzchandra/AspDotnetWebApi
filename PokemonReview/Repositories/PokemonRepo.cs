using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repositories;

public class PokemonRepo(ApiDBContext dBContext) : IPokemonRepo
{
  private readonly ApiDBContext _dBContext = dBContext;
  public ICollection<Pokemon> GetPokemons(short page, short pageSize)
  {
    return _dBContext.Pokemons.OrderBy(p => p.Name).Skip((page - 1) * pageSize).Take(pageSize).ToList();
  }

  public Pokemon? GetPokemon(int id)
  {
    return _dBContext.Pokemons.FirstOrDefault(p => p.Id == id);
  }


  public int[] AddPokemons(Pokemon[] pokemons)
  {
    _dBContext.Pokemons.AddRange(pokemons);
    _dBContext.SaveChanges();
    return pokemons.Select(p => p.Id).ToArray();
  }

  public void UpdatePokemon(int id, Pokemon pokemon)
  {
    _dBContext.Pokemons.Update(pokemon);
    _dBContext.SaveChanges();
  }
}
