using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.Repositories
{
    public interface IBuildingRepository
    {
        Task AddBuildingAsync(Building building);
        Task<Building?> GetBuildingByIdAsync(BuildingId buildingId);
        Task DeleteBuildingAsync(Building building);
    }
}
