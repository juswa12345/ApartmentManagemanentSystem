using Identity.Application.Commands;
using Identity.Application.Repositories;
using Identity.Domain.Entities;

namespace Identity.Application.CommandHandlers
{
    public class RoleCommands : IRoleCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateRoleAsync(string roleName)
        {   
            Role role = Role.Create(roleName);

            await _unitOfWork.RoleRepository.CreateRoleAsync(role);
            await _unitOfWork.SaveChangesAsync(default);
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _unitOfWork.RoleRepository.GetRolesAsync();
        }
    }
}
