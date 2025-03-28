using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Presentation.WebApp.Pages;

public class IndexModel(IProjectService projectService) : PageModel
{

    private readonly IProjectService _projectService = projectService;


    [BindProperty] public Project FormData { get; set; } = new();
    
    public List<Project> ProjectsList { get; set; } = [];
    
    
    public async Task OnGet()
    {
        var projects = await _projectService.GetProjectsAsync();

        if (projects != null)
        {
            var project = projects.FirstOrDefault();

            if (project != null)

                FormData = project;


            // ProjectsList =
            // [
            //     ..projects.Select(x => new Project
            //     {
            //         Id = x.Id,
            //         Name = x.Name,
            //         Description = x.Description,
            //         Customer = x.Customer,
            //         Budget = x.Budget,
            //         Status = x.Status,
            //         Dates = x.Dates
            //     })
            // ];
        }
        
        
    }

    public void OnPost()
    {
        
    }
}