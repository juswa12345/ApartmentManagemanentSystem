using Identity.Domain.Entities;

namespace Identity.Application.Repositories
{
    public interface IRoleRepository
    {
        Task CreateRoleAsync(Role role);

        Task<Role?> GetRoleByIdAsync(Guid id);

        Task<List<Role>> GetRolesAsync();
    }
}
