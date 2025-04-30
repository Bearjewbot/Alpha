using Data.Entities;

namespace Business.Interfaces;

public interface ITimetableService
{
    Task<TimetableEntity?> CreateTimetableAsync(DateTime startDate, DateTime endDate);
    
    Task<bool> UpdateTimetableAsync(TimetableEntity entity);
}