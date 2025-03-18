using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    public Task<TEntity?> CreateAsync(TEntity entity);
    public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null);
    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    public Task<TEntity?> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity);
    public Task<bool> DeleteAsync(TEntity entity);
    public bool IfExists(Expression<Func<TEntity, bool>> expression);
}