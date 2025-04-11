using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class BudgetFactory
{
    public static Budget MapBudget(BudgetEntity entity)
    {
        var budget = new Budget
        {
            Id = entity.Id,
            BudgetAmount = entity.Budget
        };

        return budget;
    }

    public static BudgetEntity MapBudgetEntity(decimal budget)
    {
        var entity = new BudgetEntity
        {
            Budget = budget,
        };

        return entity;
    }
}