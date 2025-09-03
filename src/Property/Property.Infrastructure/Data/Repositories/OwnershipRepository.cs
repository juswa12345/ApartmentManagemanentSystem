using Microsoft.EntityFrameworkCore;
using Property.Application.Repositories;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Repositories
{
    public class OwnershipRepository : IOwnershipRespository
    {
        private readonly PropertyDBContext _context;

        public OwnershipRepository(PropertyDBContext context)
        {
            _context = context;
        }
        public async Task AddOwnershipAsync(PropertyOwnership ownership)
        {
            await _context.PropertyOwnerships.AddAsync(ownership);
        }

        public async Task<List<PropertyOwnership>> GetPropertyOwnershipsAsync()
        {
            return await _context.PropertyOwnerships.Include(p => p.Owner).Include(p => p.Unit).ToListAsync();
        }
    }
}
