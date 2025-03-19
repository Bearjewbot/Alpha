using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusTypeEntity
{
    public int Id { get; set; }

    [Required] [MaxLength(50)]public string Status { get; set; } = string.Empty;
    
    public ICollection<ProjectEntity> Projects { get; set; } = [];   
}