using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class BudgetFactory
{
    public static Budget MapBudget(BudgetEntity entity)
    {
        var budget = new Budget
        {
            BudgetAmount = entity.Budget
        };

        return budget;
    }
}