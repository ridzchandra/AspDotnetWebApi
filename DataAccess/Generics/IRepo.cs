using System.Linq.Expressions;

namespace DataAccess.Generics;

public interface IRepo<TEntity> where TEntity : class
{
  Task<TEntity?> GetByIdAsync(int id);
  Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
  Task<IEnumerable<TEntity>> GetAllAsync(short page, short pageSize);

  Task AddAsync(TEntity entity);
  Task AddRangeAsync(IEnumerable<TEntity> entities);

  void Remove(TEntity entity);
  void RemoveRange(IEnumerable<TEntity> entities);
}