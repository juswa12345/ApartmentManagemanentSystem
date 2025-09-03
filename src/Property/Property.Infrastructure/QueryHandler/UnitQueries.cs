using Microsoft.EntityFrameworkCore;
using Property.Application.Queries;
using Property.Domain.Entities;
using Property.Infrastructure.Data;

namespace Property.Infrastructure.QueryHandler
{
    public class UnitQueries : IUnitQueries
    {
        private readonly PropertyDBContext _context;

        public UnitQueries(PropertyDBContext context)
        {
            _context = context;
        }

        public async Task<Unit?> GetUnitByIdAsync(Guid id)
        {
            return await _context.Units.FirstOrDefaultAsync();
        }

        public async Task<List<Unit>> GetUnitsAsync()
        {
            return await _context.Units.ToListAsync();
        }
    }
}
