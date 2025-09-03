using Leasing.Domain.Entities;

namespace Leasing.Application.Commands
{
    public interface IUnitCommands
    {
        Task AddUnitAsync(Guid id, string buildingName, string unitNumber, int floor, double monthlyRent, int occupancy);

        Task DeleteUnitAsync(Guid id, CancellationToken cancellationToken);

        Task<Unit> UpdateUnitAsync(Guid id, string buildingName, string street, string city, string state, string zip, int numberOfFloors, int yearBuilt, string? notes);
    }
}
