using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class TimetableRepository(DataContext context) : BaseRepository<TimetableEntity>(context), ITimetableRepository
{
    
}