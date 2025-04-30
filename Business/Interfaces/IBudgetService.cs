using Data.Entities;

namespace Business.Interfaces;

public interface IBudgetService
{
    Task<BudgetEntity?> CreateBudgetAsync(decimal budget);

    Task<bool> UpdateBudgetAsync(BudgetEntity entity);
}