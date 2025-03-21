using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusFactory
{
    public static StatusType MapStatus(StatusTypeEntity entity)
    {
        var status = new StatusType
        {
            Id = entity.Id,
            Status = entity.Status
        };

        return status;
    } 
}