using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IStatusTypeService
{
    Task<IEnumerable<StatusType>?> GetAllAsync();
}