using Business.Factories;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    private readonly ICustomerRepository _repository = repository;

    public async Task<CustomerEntity?> CreateCustomerAsync(string customer)
    {
        var entity = CustomerFactory.MapCustomerEntity(customer);

        var savedEntity = await _repository.CreateAsync(entity);

        if (savedEntity != null)
        {
            return savedEntity;
        }

        return null; 
    }
    
    public async Task<bool> UpdateCustomerAsync(CustomerEntity entity)
    {
        var result = await _repository.UpdateAsync(x => x.Id == entity.Id, entity);
        
        if (result != null)
        {
            return true;
        }
        return false;
    }
}