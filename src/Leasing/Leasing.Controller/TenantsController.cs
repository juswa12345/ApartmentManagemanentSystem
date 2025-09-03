using Leasing.Application.Commands;
using Leasing.Application.Response;
using Leasing.Controller.Request;
using Microsoft.AspNetCore.Mvc;

namespace Leasing.Controller
{
    [Route("api/tenants")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantCommands _commands;


        public TenantsController(ITenantCommands commands)
        {
            _commands = commands;
        }

        [HttpGet]
        public async Task<ActionResult<List<TenantReponse>>> GetTenantsAsync()
        {
            var tenants = await _commands.GetAllTenantsAsync();


            return Ok(tenants);
        }

        [HttpGet("{tenantId}")]

        public async Task<ActionResult<TenantReponse>> GetTenantByIdAsync(Guid id)
        {
            var tenant = await _commands.GetTenantByIdAsync(id);

            return Ok(tenant);
        }

        [HttpDelete("{tenantId}")]

        public async Task<IActionResult> DeleteTenantAsync(Guid id)
        {
            await _commands.RemoveTenantAsync(id);

            return Ok();
        }

        [HttpPut("{tenantId}")]
        public async Task<IActionResult> UpdateTenantAsync(Guid id, TenantRequest request)
        {
            await _commands.UpdateTenantAsync(id, request.FirstName, request.LastName, request.Email, request.PhoneNumber);

            return Ok();
        }

    }
}
