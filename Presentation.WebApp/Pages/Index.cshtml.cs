using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.WebApp.Models;


namespace Presentation.WebApp.Pages;

public class IndexModel(IProjectService projectService, IStatusTypeService statusService, IBudgetService budgetService, ICustomerService customerService, ITimetableService timetableService) : PageModel
{

    private readonly IProjectService _projectService = projectService;
    private readonly IStatusTypeService _statusService = statusService;
    private readonly IBudgetService _budgetService = budgetService;
    private readonly ICustomerService _customerService = customerService;
    private readonly ITimetableService _timetableService = timetableService;
    
    [BindProperty] public AddProjectFormModel FormData { get; set; } = new();
    [BindProperty] public List<ShowProjectsModel> ProjectsList { get; set; } = [];

     public List<SelectListItem> StatusList { get; set; } = [];
    
    public async Task OnGet()
    {
        var projects = await _projectService.GetProjectsAsync();

        if (projects != null)
        {
            ProjectsList =
            [
                ..projects.Select(x => new ShowProjectsModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Customer = x.Customer,
                    Status = x.Status,
                }).ToList()
            ];
        }

        var statusOptions = await _statusService.GetAllAsync();

        if (statusOptions != null)
        {
            StatusList = statusOptions.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Status
            }).ToList();
        }

    }
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _projectService.DeleteProjectAsync(id);
        
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCreateAsync()
    {
        var budgetEntity = await _budgetService.CreateBudgetAsync(FormData.Budget);
        var customerEntity = await _customerService.CreateCustomerAsync(FormData.Customer);
        var timetableEntity = await _timetableService.CreateTimetableAsync(FormData.StartDate, FormData.EndDate);

        if (budgetEntity != null && customerEntity != null && timetableEntity != null)
        {
            var mappedProject = new ProjectFormRegistration
            {
                Name = FormData.Name,
                Description = FormData.Description,
                CustomerId = customerEntity.Id,
                TimetableId = timetableEntity.Id,
                BudgetId = budgetEntity.Id,
                StatusId = FormData.StatusId
            };

            try
            {
                await _projectService.CreateProjectAsync(mappedProject);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw;
            }
        }
        
        return RedirectToPage();
    }
}