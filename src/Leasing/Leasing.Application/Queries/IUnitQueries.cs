using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface IUnitQueries
    {
        Task<UnitResponse> GetUnitByIdAsync(Guid id);
        Task<List<UnitResponse>> GetUnitsAsync();
    }
}
