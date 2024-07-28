using DataAccess.Generics;
using PokemonReview.Models;

namespace PokemonReview.DataAccess.Interfaces;

public interface IPokemonRepo : IRepo<Pokemon>
{
  Task<IEnumerable<Pokemon>> GetPokemonsWithOwnersFromGym(short page, short pageSize, string gym);
}
