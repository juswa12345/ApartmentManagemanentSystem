using Microsoft.EntityFrameworkCore;
using Property.Application.Repositories;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Repositories
{
    public class UnitRepository : IUnitReposirtory
    {
        private readonly PropertyDBContext _context;

        public UnitRepository(PropertyDBContext context)
        {
            _context = context;
        }

        public async Task AddUnitAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
        }

        public Task DeleteUnitAsync(Unit unit)
        {
            _context.Units.Remove(unit);

            return Task.CompletedTask;
        }

        public Task<Unit?> GetUnitByIdAsync(UnitId unitId)
        {
            var unit = _context.Units.FirstOrDefaultAsync();

            return unit;

        }

        public Task UpdateUnitAsync(Unit unit)
        {
            _context.Units.Update(unit);
            return Task.CompletedTask;
        }
    }
}
