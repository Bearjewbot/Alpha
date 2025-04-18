using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusTypeEntity
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(50)] public string ProjectStatus { get; set; } = string.Empty;
    
    public ICollection<ProjectEntity> Projects { get; set; } = [];   
}