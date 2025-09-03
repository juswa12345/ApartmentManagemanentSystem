using Microsoft.AspNetCore.Mvc;
using Property.Application.Commnds;
using Property.Application.Response;
using Property.Controller.Request;

namespace Property.Controller
{
    [Route("api/ownerships")]
    [ApiController]
    public class OwnershipsController : ControllerBase
    {
        private readonly IPropertyOwnershipCommands _commands;

        public OwnershipsController(IPropertyOwnershipCommands commands)
        {
            _commands = commands;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwnership([FromBody] OwnershipRequest request)
        {
            await _commands.CreateOwnership(new Guid(request.ownerId), new Guid(request.unitId));

            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<List<OwnershipResponse>>> GetAllOwnerships()
        {
            var ownerships = await _commands.GetOwnershipsAsync();


            return Ok(ownerships);
        }
    }
}
