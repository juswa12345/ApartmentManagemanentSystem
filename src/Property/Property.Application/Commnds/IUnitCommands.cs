using FluentResults;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Application.Commnds
{
    public interface IUnitCommands
    {
        Task<Result<UnitResponse>> AddUnitAsync(Guid ownerId, Guid id, string unitNumber, int floor, double monthlyRent, int occupancy);

        Task DeleteUnitAsync(Guid id, CancellationToken cancellationToken);

        Task<Unit> UpdateUnitAsync(Guid id, string buildingName, string street, string city, string state, string zip, int numberOfFloors, int yearBuilt, string? notes);
    }
}
