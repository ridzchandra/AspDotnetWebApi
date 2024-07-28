namespace PokemonReview.DataAccess.Interfaces;

public interface IUnitOfWork : IDisposable
{
  IPokemonRepo Pokemons { get; }
  Task<int> CompleteAsync();
}