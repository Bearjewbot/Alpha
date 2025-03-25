using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Presentation.WebApp.Pages;

public class IndexModel(IProjectService projectService) : PageModel
{

    private readonly IProjectService _projectService = projectService;

    public IEnumerable<Project> ProjectsList { get; set; } = [];

    public async Task OnGet()
    {
        var projects = await _projectService.GetProjectsAsync();
        ProjectsList =
        [
            ..projects.Select(x => new Project
            {
                Id = 0,
                Name = null,
                Description = null,
                Customer = null,
                Budget = null,
                Status = null,
                Dates = null
            })
        ];
    }

    public void OnPost()
    {
        
    }
}