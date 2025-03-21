namespace Business.Models;

public class Project
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Customer? Customer { get; set;  } 
    
    public Budget? Budget { get; set; }
    
    public StatusType? Status { get; set; }
    
    public Timetable? Dates { get; set; }
}