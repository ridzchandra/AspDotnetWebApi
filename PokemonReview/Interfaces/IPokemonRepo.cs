using PokemonReview.Models;

namespace PokemonReview.Interfaces;

public interface IPokemonRepo
{
  ICollection<Pokemon> GetPokemons(byte page, byte pageSize);
  Pokemon? GetPokemon(int id);

  int[] AddPokemons(Pokemon[] pokemons);
}
