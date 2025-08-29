using Microsoft.EntityFrameworkCore;
using Property.Application.Repositories;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PropertyDBContext _context;

        public OwnerRepository(PropertyDBContext context)
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
