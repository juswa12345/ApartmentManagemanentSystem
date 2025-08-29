using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Commands
{
    public interface IRoleCommands
    {
        Task CreateRoleAsync(string roleName);

        Task<List<Role>> GetRolesAsync();
    }
}
