using Business.Factories;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class TimetableService(ITimetableRepository repository) : ITimetableService
{

    private readonly ITimetableRepository _repository = repository;

    public async Task<TimetableEntity?> CreateTimetableAsync(DateTime startDate, DateTime endDate)
    {
        var entity = TimetableFactory.MapTimetableEntity(startDate, endDate);

        var savedEntity = await _repository.CreateAsync(entity);

        if (savedEntity != null)
        {
            return savedEntity;
        }

        return null; 
    }
}