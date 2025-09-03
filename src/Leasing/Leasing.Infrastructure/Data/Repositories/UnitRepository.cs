using Leasing.Application.Repositories;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class UnitRepository : IUnitReposirtory
    {
        private readonly LeasingDBContext _context;

        public UnitRepository(LeasingDBContext context)
        {
            _context = context;
        }

        public async Task AddUnitAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
        }

        public async Task DeleteUnitAsync(Unit unit)
        {
            _context.Units.Remove(unit);
        }

        public Task<Unit?> GetUnitByIdAsync(UnitId unitId)
        {
            var unit = _context.Units.Where(u => u.Id == unitId).FirstOrDefaultAsync();

            return unit;

        }
    }
}
