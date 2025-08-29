using FluentResults;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Application.Commnds
{
    public interface IBuildingCommands
    {
        Task<BuildingResponse> AddBuildingAsync(string buildingName, string buildingNumber, string street, string city, string state, string zip, int numberOfFloors, int yearBuilt);

        Task DeleteBuildingAsync(Guid id, CancellationToken cancellationToken);

        Task<Building> UpdateBuildingAsync(Guid id, string buildingName, string street, string city, string state, string zip, int numberOfFloors, int yearBuilt, string? notes);
    }
}
