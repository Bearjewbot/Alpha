using System.ComponentModel.DataAnnotations;
using Business.Models;

namespace Presentation.WebApp.Models;

public class AddProjectFormModel
{
    [Required(ErrorMessage = "You must enter the project name")]
    [MinLength(3, ErrorMessage = "The project name is too short")]
    [MaxLength(100, ErrorMessage = "The project name is too long")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "You must enter a project description")]
    [MinLength(5, ErrorMessage = "The description must be a bit more detailed")]
    [MaxLength(200, ErrorMessage = "The description is too long")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "You must enter a customer")]
    public string Customer { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "You must select a starting date")] 
    public DateTime StartDate { get; set; }
    
    [Required(ErrorMessage = "You must select an end date")]
    public DateTime EndDate { get; set; }
    
    [Required(ErrorMessage = "You must specify the projects budget")]
    public Decimal Budget { get; set; }

    [Required(ErrorMessage = "You must select a project status")] 
    public int StatusId { get; set; }
}