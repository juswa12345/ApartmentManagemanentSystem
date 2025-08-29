using Identity.Application.Commands;
using Identity.Application.Repositories;
using Identity.Domain.Entities;

namespace Identity.Application.CommandHandlers
{
    public class RoleCommands : IRoleCommands
    {
        private readonly IRoleRepository _roleRepository;

        public RoleCommands(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task CreateRoleAsync(string roleName)
        {   
            Role role = Role.Create(roleName);

            await _roleRepository.CreateRoleAsync(role);
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _roleRepository.GetRolesAsync();
        }
    }
}
