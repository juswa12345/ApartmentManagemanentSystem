using Identity.Application.Repositories;
using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IdentityDbContext _context;

        public RoleRepository(IdentityDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);

            await _context.SaveChangesAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(Guid id)
        {
            return await _context.Roles.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
