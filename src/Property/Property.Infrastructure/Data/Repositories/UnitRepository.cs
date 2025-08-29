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

        public async Task DeleteUnitAsync(Unit unit)
        {
            _context.Units.Remove(unit);
        }

        public Task<Unit?> GetUnitByIdAsync(UnitId unitId)
        {
            var unit = _context.Units.Include(u => u.Building).Include(u => u.Owner).FirstOrDefaultAsync();


            return unit;

        }
    }
}
