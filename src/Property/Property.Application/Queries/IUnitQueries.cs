using Property.Application.Response;

namespace Property.Application.Queries
{
    public interface IUnitQueries
    {
        Task<UnitResponse> GetUnitByIdAsync(Guid id);
        Task<List<UnitResponse>> GetUnitsAsync();
    }
}
