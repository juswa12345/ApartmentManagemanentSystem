using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Application.Queries
{
    public interface IBuildingQueries
    {
        Task<BuildingResponse?> GetBuildingByIdAsync(Guid id);
        Task<List<BuildingResponse>> GetBuildingsAsync();

        Task<BuildingResponse?> UpdateBuildAsync(Building building);
    }
}
