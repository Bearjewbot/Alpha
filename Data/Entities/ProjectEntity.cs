using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{
    public int Id { get; set; }

    [Required] [MaxLength(50)] public string Name { get; set; } = string.Empty;

    [Required] [MaxLength(150)]public string Description { get; set; } = string.Empty;


    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
    
    public int TimeTableId { get; set; }
    public TimetableEntity TimeTable { get; set; } = null!;

    public int StatusId { get; set; }
    public StatusTypeEntity StatusType { get; set; } = null!;
    
    public int BudgetId { get; set; }
    public BudgetEntity Budget { get; set; } = null!;
    
}