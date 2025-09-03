using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Application.Queries
{
    public interface IUnitQueries
    {
        Task<Unit?> GetUnitByIdAsync(Guid id);
        Task<List<Unit>> GetUnitsAsync();
    }
}
