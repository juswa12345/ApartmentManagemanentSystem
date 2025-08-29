using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Application.Queries
{
    public interface IBuildingQueries
    {
        Task<BuildingResponse?> GetBuildingByIdAsync(Guid id);
        Task<List<BuildingResponse>> GetBuildingsAsync();

        Task<BuildingResponse?> UpdateBuildAsync(Building building);
    }
}
