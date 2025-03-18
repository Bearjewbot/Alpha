using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{

    protected readonly DataContext Context = context;
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();
    
    
    public virtual async Task<TEntity?> CreateAsync(TEntity entity)
    {
        try
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
        catch (DbUpdateConcurrencyException e)
        {
            Debug.WriteLine(e);
            return null;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null;
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null)
    {
        try
        {
            if (expression == null)
            {
                return await DbSet.ToListAsync();
            }

            return await DbSet.Where(expression).ToListAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            Debug.WriteLine(e);
            return [];
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return [];
        }
    }
    
    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await DbSet.FirstOrDefaultAsync(expression);
            return entity;
        }
        catch (DbUpdateConcurrencyException e)
        {
            Debug.WriteLine(e);
            return null;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null;
        }
    }

    public virtual async Task<TEntity?> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        try
        {
            var oldEntity = await DbSet.FirstOrDefaultAsync(expression);

            if (oldEntity != null)
            {
                DbSet.Entry(oldEntity).CurrentValues.SetValues(entity);
                await Context.SaveChangesAsync();
                return entity;
            }
            return null;
        }
        catch (DbUpdateConcurrencyException e)
        {
            Debug.WriteLine(e);
            return null;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null;
        }
    }

    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException e)
        {
            Debug.WriteLine(e);
            return false;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return false;
        }
    }

    public bool IfExists(Expression<Func<TEntity, bool>> expression)
    {
        return DbSet.Any(expression);
    }
}

