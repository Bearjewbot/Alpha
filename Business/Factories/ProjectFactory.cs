using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity? MapProjectEntity(ProjectFormRegistration form)
    {
        var entity = new ProjectEntity
        {
            Name = form.Name,
            Description = form.Description,
            CustomerId = form.CustomerId,
            TimeTableId = form.TimetableId,
            StatusId = form.StatusTypeId,
            BudgetId = form.BudgetId
        };

        return entity;
    }

    public static Project? MapProject(ProjectEntity entity)
    {
        var project = new Project
        {
            Name = entity.Name,
            Description = entity.Description,
            Customer = CustomerFactory.MapCustomer(entity.Customer),
            Budget = BudgetFactory.MapBudget(entity.Budget),
            Status = StatusFactory.MapStatus(entity.StatusType),
            Dates = TimetableFactory.MapTimetable(entity.TimeTable)
        };

        return project;
    }
}