using Business.Factories;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class BudgetService(IBudgetRepository repository) : IBudgetService
{
    private readonly IBudgetRepository _repository = repository;

    
    public async Task<BudgetEntity?> CreateBudgetAsync(decimal budget)
    {
        var entity = BudgetFactory.MapBudgetEntity(budget);

        var savedEntity = await _repository.CreateAsync(entity);

        if (savedEntity != null)
        {
            return savedEntity;
        }

        return null;
    }
}