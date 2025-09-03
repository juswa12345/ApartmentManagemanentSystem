using Leasing.Application.Repositories;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly LeasingDBContext _context;

        public OwnerRepository(LeasingDBContext context)
        {
            _context = context;
        }

        public async Task AddOwnerAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
        }

        public async Task<Owner?> GetOwnerByIdAsync(OwnerId id)
        {
            return await _context.Owners.Where(o => o.Id == id).FirstOrDefaultAsync();
        }
    }
}
