using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Generics;

public class Repo<TEntity>(DbContext context) : IRepo<TEntity> where TEntity : class
{
  protected readonly DbContext _context = context;

  public async Task<TEntity?> GetByIdAsync(int id)
  {
    return await _context.Set<TEntity>().FindAsync(id);
  }

  public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate)
  {
    return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
  }

  public async Task<IEnumerable<TEntity>> GetAllAsync(short page, short pageSize)
  {
    return await _context.Set<TEntity>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
  }

  public async Task AddAsync(TEntity entity)
  {
    await _context.Set<TEntity>().AddAsync(entity);
  }

  public async Task AddRangeAsync(IEnumerable<TEntity> entities)
  {
    await _context.Set<TEntity>().AddRangeAsync(entities);
  }

  // AddAsync and AddRangeAsync: These methods can involve I/O operations, such as generating keys for the entities, which might require communication with the database. Therefore, they have asynchronous versions to avoid blocking the calling thread.
  // Remove and RemoveRange: These methods only mark the entities for deletion in the context, which is an in-memory operation and does not involve any I/O.Hence, they do not have asynchronous versions.
  public void Remove(TEntity entity)
  {
    _context.Set<TEntity>().Remove(entity);
  }

  public void RemoveRange(IEnumerable<TEntity> entities)
  {
    _context.Set<TEntity>().RemoveRange(entities);
  }
}