using PokemonReview.DataAccess.Interfaces;
using PokemonReview.DataAccess.Repos;

namespace PokemonReview.DataAccess;

public class UnitOfWork(PokemonReviewDBContext context) : IUnitOfWork
{
  private readonly PokemonReviewDBContext _context = context;
  public IPokemonRepo Pokemons { get; } = new PokemonRepo(context);

  public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

  public void Dispose() => _context.Dispose();
}