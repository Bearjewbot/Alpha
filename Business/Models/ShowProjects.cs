namespace Business.Models;

public class ShowProjects
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public Customer Customer { get; set; } = null!; 
    
    public StatusType Status { get; set; } = null!;
    
}