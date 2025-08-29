using FluentResults;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Application.Commnds
{
    public interface IUnitCommands
    {
        Task<Result<UnitResponse>> AddUnitAsync(Guid id, string unitNumber, int floor, double monthlyRent, int occupancy);

        Task DeleteUnitAsync(Guid id, CancellationToken cancellationToken);

        Task<Unit> UpdateUnitAsync(Guid id, string buildingName, string street, string city, string state, string zip, int numberOfFloors, int yearBuilt, string? notes);
    }
}
