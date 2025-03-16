using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<TimetableEntity> Timetables { get; set; }
    public DbSet<BudgetEntity> Budgets { get; set; }    
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    
}