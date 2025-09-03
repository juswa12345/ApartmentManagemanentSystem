using Microsoft.EntityFrameworkCore;
using Property.Application.Repositories;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRespository
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

        public Task DeleteOwnerAync(Owner owner)
        {
            _context.Owners.Remove(owner);

            return Task.CompletedTask;
        }

        public async Task<Owner?> GetOwnerByIdAsync(OwnerId id)
        {
            return await _context.Owners.Where(o => o.Id == id).Include(o => o.PropertiesOwned).ThenInclude(p => p.Unit).FirstOrDefaultAsync();
        }

        public Task UpdateOwnerAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            return Task.CompletedTask;
        }
    }
}
