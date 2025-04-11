using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static Customer MapCustomer(CustomerEntity entity)
    {
        var customer = new Customer
        {
            Id = entity.Id,
            Name = entity.Name,
            OurReference = entity.OurReference
        };

        return customer;
    }

    public static CustomerEntity MapCustomerEntity(string customer)
    {
        var entity = new CustomerEntity
        {
            Name = customer
        };

        return entity;
    }
}