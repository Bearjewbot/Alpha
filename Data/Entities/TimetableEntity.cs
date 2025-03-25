using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class TimetableEntity
{
    [Key] public int Id { get; set; }
    
    [Required] public DateTime StartDate { get; set; }
    
    [Required] public DateTime EndDate { get; set; }

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}