using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Presentation.WebApp.Pages;

public class IndexModel(IProjectService projectService) : PageModel
{
    [BindProperty] public List<ShowProjects> ProjectsList { get; set; } = [];
    
    public async Task OnGet()
    {
        var projects = await projectService.GetProjectsAsync();

        if (projects != null)
        {
            ProjectsList =
            [
                ..projects.Select(x => new ShowProjects()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Customer = x.Customer,
                    Status = x.Status,
                }).ToList()
            ];
        }
        
        
    }

    public void OnPost()
    {
        
    }
}