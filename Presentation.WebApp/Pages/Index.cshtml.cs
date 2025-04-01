using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Presentation.WebApp.Pages;

public class IndexModel(IProjectService projectService) : PageModel
{
    
    public void OnGet()
    {

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

    public void OnPost()
    {
        
    }
}