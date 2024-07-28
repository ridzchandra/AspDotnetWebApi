using Microsoft.EntityFrameworkCore;
using DataAccess.Generics;
using PokemonReview.DataAccess.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.DataAccess.Repos;

public class PokemonRepo(PokemonReviewDBContext dbContext) : Repo<Pokemon>(dbContext), IPokemonRepo
{
  private PokemonReviewDBContext PRDBContext
  {
    get { return (PokemonReviewDBContext)_context; }
  }
  public async Task<IEnumerable<Pokemon>> GetPokemonsWithOwnersFromGym(short page, short pageSize, string gym)
  {
    return await PRDBContext.Pokemons
      .Include(p => p.Owners)
      .Where(p => p.Owners.Any(o => o.Gym == gym))
      .Skip((page - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();
  }
}
