using PokemonReview.Models;

namespace PokemonReview.Interfaces;

public interface IPokemonRepo
{
  ICollection<Pokemon> GetPokemons(short page, short pageSize);
  Pokemon? GetPokemon(int id);

  int[] AddPokemons(Pokemon[] pokemons);

  void UpdatePokemon(int id, Pokemon pokemon);
}
