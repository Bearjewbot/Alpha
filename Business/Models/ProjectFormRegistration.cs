using System.Runtime.InteropServices.JavaScript;

namespace Business.Models;

public class ProjectFormRegistration
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public int CustomerId { get; set; }
    
    public int TimetableId { get; set; }    
    
    public int BudgetId { get; set; }
    
    public int StatusId { get; set; }
}