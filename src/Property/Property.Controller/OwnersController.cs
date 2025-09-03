using Microsoft.AspNetCore.Mvc;
using Property.Application.Commnds;
using Property.Application.Response;
using Property.Controller.Request;

namespace Property.Controller
{
    [Route("api/owners")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerCommands _commands;

        public OwnersController(IOwnerCommands commands)
        {
            _commands = commands;
        }

        [HttpGet]
        public async Task<ActionResult<List<OwnerReponse>>> GetOwnersAsync()
        {
            var owners = await _commands.GetOwnersAsync();

            return Ok(owners);
        }

        [HttpGet("{ownerID}")]

        public async Task<ActionResult<OwnerReponse>> GetOwnerByIdAsync(Guid ownerID)
        {
            var owner = await _commands.GetOwnerByIdAsync(ownerID);
            if (owner is null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        [HttpPut("{ownerID}")]

        public async Task<IActionResult> UpdateOwnerAsync(Guid ownerId, [FromBody]OwnerRequest ownerRequest)
        {
            await _commands.UpdateOwnerAsync(ownerId, ownerRequest.FirstName, ownerRequest.LastName, ownerRequest.Email, ownerRequest.ContactNumber, ownerRequest.Age,  ownerRequest.Street, ownerRequest.City, ownerRequest.State, ownerRequest.ZipCode);

            return Ok();
        }

        [HttpDelete("{ownerId}")]

        public async Task<IActionResult> DeleteOwnerAsync(Guid ownerId)
        {
            await _commands.DeleteOwnerAsync(ownerId);
            return Ok();
        }
    }
}
