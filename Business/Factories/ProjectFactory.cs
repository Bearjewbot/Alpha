using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity? MapCreateProject(ProjectFormRegistration form)
    {
        var entity = new ProjectEntity
        {
            Name = form.Name,
            Description = form.Description,
            CustomerId = form.CustomerId,
            TimeTableId = form.TimetableId,
            BudgetId = form.BudgetId
        };

        return entity;
    }

    public static Project MapProject(ProjectEntity entity)
    {
        var project = new Project
        {   
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Customer = CustomerFactory.MapCustomer(entity.Customer),
            Budget = BudgetFactory.MapBudget(entity.Budget),
            Status = StatusFactory.MapStatus(entity.Status),
            Dates = TimetableFactory.MapTimetable(entity.TimeTable)
        };

        return project;
    }
    
    public static Project MapProjects(ProjectEntity entity)
    {
        var project = new Project
        {   
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Customer = CustomerFactory.MapCustomer(entity.Customer),
            Status = StatusFactory.MapStatus(entity.Status),
        };

        return project;
    }

    public static ProjectEntity MapProjectEntity(Project project)
    {
        var entity = new ProjectEntity
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CustomerId = project.Customer.Id,
            TimeTableId = project.Dates.Id,
            StatusId = project.Status.Id,
            BudgetId = project.Budget.Id,
        };

        return entity;
    }
}