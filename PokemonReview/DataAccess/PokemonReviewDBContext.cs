using Microsoft.EntityFrameworkCore;
using PokemonReview.Models;

namespace PokemonReview.DataAccess;

public class PokemonReviewDBContext(DbContextOptions<PokemonReviewDBContext> options) : DbContext(options)
{
  public DbSet<Reviewer> Reviewers { get; set; } = null!;
  public DbSet<Review> Reviews { get; set; } = null!;
  public DbSet<Owner> Owners { get; set; } = null!;
  public DbSet<Country> Countries { get; set; } = null!;
  public DbSet<Pokemon> Pokemons { get; set; } = null!;
  public DbSet<Category> Categories { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Reviewer>().ToTable("reviewer");
    modelBuilder.Entity<Review>().ToTable("review");
    modelBuilder.Entity<Owner>().ToTable("owner").HasMany(o => o.Pokemons).WithMany(p => p.Owners);
    modelBuilder.Entity<Country>().ToTable("country");
    modelBuilder.Entity<Pokemon>().ToTable("pokemon").HasMany(p => p.Categories).WithMany(c => c.Pokemons);
    modelBuilder.Entity<Category>().ToTable("category");
  }
}
