using Identity.Application.Commands;
using Identity.Controller.Request;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controller
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleCommands _roleCommands;

        public RolesController(IRoleCommands roleCommands)
        {
            _roleCommands = roleCommands;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleRequest roleRequest)
        {
            await _roleCommands.CreateRoleAsync(roleRequest.Name);

            return Ok(new { Message = $"Role '{roleRequest.Name}' created successfully." });
        }

        [HttpGet]


        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleCommands.GetRolesAsync();

            return Ok(roles);
        }
    }
}
