using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Application.Repositories
{
    public interface IBuildingRepository
    {
        Task AddBuildingAsync(Building building);
        Task<Building?> GetBuildingByIdAsync(BuildingId buildingId);
        Task DeleteBuildingAsync(Building building);
        Task UpdateBuildingAsync(Building building);
    }
}
