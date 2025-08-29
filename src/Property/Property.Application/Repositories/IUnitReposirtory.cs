using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Application.Repositories
{
    public interface IUnitReposirtory
    {
        Task AddUnitAsync(Unit unit);

        Task<Unit?> GetUnitByIdAsync(UnitId unitId);

        Task DeleteUnitAsync(Unit unit);
    }
}
