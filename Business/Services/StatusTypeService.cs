using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class StatusTypeService(IStatusTypeRepository repository) : IStatusTypeService
{

    private readonly IStatusTypeRepository _repository = repository;

    public async Task<IEnumerable<StatusType>?> GetAllAsync()
    {
        var statusList = await _repository.GetAllAsync();
        return statusList.Select(StatusFactory.MapStatus);
    }
}