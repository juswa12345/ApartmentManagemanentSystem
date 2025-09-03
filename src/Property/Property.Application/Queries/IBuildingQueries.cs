using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Application.Queries
{
    public interface IBuildingQueries
    {
        Task<Building?> GetBuildingByIdAsync(Guid id);
        Task<List<Building>> GetBuildingsAsync();
    }
}
