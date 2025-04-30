using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.WebApp.Models;


namespace Presentation.WebApp.Pages;

public class IndexModel(IProjectService projectService, IStatusTypeService statusService, IBudgetService budgetService, ICustomerService customerService, ITimetableService timetableService, IProjectRepository projectRepository) : PageModel
{
    [BindProperty] public ProjectFormModel FormData { get; set; } = new();
    [BindProperty] public List<ShowProjectsModel> ProjectsList { get; set; } = [];
    [BindProperty] public List<SelectListItem> StatusList { get; set; } = [];
    
    public async Task OnGet()
    {
        var statusOptions = await statusService.GetAllAsync();

        if (statusOptions != null)
        {
            StatusList = statusOptions.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Status
            }).ToList();
        }
        
        var projects = await projectService.GetProjectsAsync();

        if (projects != null && StatusList.Count > 0)
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
                    Dates = x.Dates,
                    Budget = x.Budget,
                }).ToList()
            ];
        }
        
    }
    
    public async Task<IActionResult> OnPostFilterProjectsAllAsync()
    {
        var projects = await projectService.GetProjectsAsync();

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
                    Dates = x.Dates,
                    Budget = x.Budget,
                }).ToList()
            ];
            return Page();
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostFilterProjectsStartedAsync()
    {
        var projects = await projectService.GetFilteredProjectsAsync(x => x.StatusId == 1);

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
                    Dates = x.Dates,
                    Budget = x.Budget,
                }).ToList()
            ];
            return Page();
        }
        return RedirectToPage();
    }
    
    public async Task<IActionResult> OnPostFilterProjectsCompletedAsync()
    {
        var projects = await projectService.GetFilteredProjectsAsync(x => x.StatusId == 2);

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
                    Dates = x.Dates,
                    Budget = x.Budget,
                }).ToList()
            ];
            return Page();
        }
        return RedirectToPage();
    }
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await projectService.DeleteProjectAsync(id);
        
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCreateAsync()
    {
        var budgetEntity = await budgetService.CreateBudgetAsync(FormData.Budget);
        var customerEntity = await customerService.CreateCustomerAsync(FormData.Customer);
        var timetableEntity = await timetableService.CreateTimetableAsync(FormData.StartDate, FormData.EndDate);

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
                await projectService.CreateProjectAsync(mappedProject);
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostUpdateAsync(int id)
    {

        var previousEntity = await projectRepository.GetAsync(x => x.Id == id);

        if (previousEntity != null)
        {
            try
            {
                await budgetService.UpdateBudgetAsync(new BudgetEntity
                {
                    Id = previousEntity.BudgetId,
                    Budget = FormData.Budget
                });

                await timetableService.UpdateTimetableAsync(new TimetableEntity
                {
                    Id = previousEntity.TimeTableId,
                    StartDate = FormData.StartDate,
                    EndDate = FormData.EndDate
                });

                await customerService.UpdateCustomerAsync(new CustomerEntity
                {
                    Id = previousEntity.CustomerId,
                    Name = FormData.Customer
                });

                await projectService.UpdateProjectAsync(new ProjectEntity
                {
                    Id = id,
                    Name = FormData.Name,
                    Description = FormData.Description,
                    CustomerId = previousEntity.CustomerId,
                    TimeTableId = previousEntity.TimeTableId,
                    StatusId = FormData.StatusId,
                    BudgetId = previousEntity.BudgetId
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        return RedirectToPage(); 
    }
}