using Data.Entities;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<CustomerEntity?> CreateCustomerAsync(string customer);

    Task<bool> UpdateCustomerAsync(CustomerEntity entity);
}