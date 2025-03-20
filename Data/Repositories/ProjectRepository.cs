using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync(Expression<Func<ProjectEntity, bool>>? expression = null)
    {
        try
        {
            if (expression == null)
            {
                return await DbSet
                    .Include(x => x.Budget)
                    .Include(x => x.Customer)
                    .Include(x => x.StatusType)
                    .Include(x => x.TimeTable)
                    .ToListAsync();
            }
            
            return await DbSet
                .Where(expression)
                .Include(x => x.Budget)
                .Include(x => x.Customer)
                .Include(x => x.StatusType)
                .Include(x => x.TimeTable)
                .ToListAsync();;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return [];
        }
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        try
        {
            return await DbSet
                .Include(x => x.Budget)
                .Include(x => x.Customer)
                .Include(x => x.StatusType)
                .Include(x => x.TimeTable)
                .FirstOrDefaultAsync(expression);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null;
        }
    }
}   