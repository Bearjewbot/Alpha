using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerEntity
{
    [Required] public string Name { get; set; } = string.Empty;

    public string OurReference { get; set; } = string.Empty;
    
    public ICollection<ProjectEntity> Projects { get; set; } = [];   
}