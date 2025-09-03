using Leasing.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Leasing.Controller
{
    [Route("api/leasings")]
    [ApiController]
    public class LeasingsController : ControllerBase
    {
        private readonly ILeasingCommands _leasingCommands;

        public LeasingsController(ILeasingCommands leasingCommands)
        {
            _leasingCommands = leasingCommands;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaseAgreement(Guid unitId, Guid ownerId, Guid tenantId)
        {
            await _leasingCommands.CreateLeaseAgreementAsync(unitId, tenantId, ownerId, default);

            return Ok();
        }
    }
}
