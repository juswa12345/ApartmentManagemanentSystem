using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.Repositories
{
    public interface IUnitReposirtory
    {
        Task AddUnitAsync(Unit unit);

        Task<Unit?> GetUnitByIdAsync(UnitId unitId);

        Task DeleteUnitAsync(Unit unit);
    }
}
