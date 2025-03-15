using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class BudgetEntity
{
    public int Id { get; set; }
    
    [Required] public decimal Budget { get; set; }   
    
    public ICollection<ProjectEntity> Projects { get; set; } = [];   
}