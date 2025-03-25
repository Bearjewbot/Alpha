using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerEntity
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(100)]public string Name { get; set; } = string.Empty;

    [MaxLength(100)]public string OurReference { get; set; } = string.Empty;
    
    public ICollection<ProjectEntity> Projects { get; set; } = [];   
}