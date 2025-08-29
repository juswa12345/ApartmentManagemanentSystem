using Property.Controller.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Application.Commnds;
using Property.Application.Errors;
using Property.Application.Queries;
using Property.Application.Response;

namespace Property.Controller
{

    [Route("api/units")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitCommands _unitCommands;
        private readonly IUnitQueries _unitQueries;

        public UnitsController(IUnitCommands unitCommands, IUnitQueries unitQueries)
        {
            _unitCommands = unitCommands;
            _unitQueries = unitQueries;
        }

        [HttpPost("{buildingId}")]
        public async Task<ActionResult<UnitResponse>> AddNewUnitAsync([FromQuery]Guid buildingId, Guid ownerId, [FromBody]UnitRequest unitRequest)
        {

            var result = await _unitCommands.AddUnitAsync(ownerId, buildingId, unitRequest.UnitNumber, unitRequest.Floor, unitRequest.MonthlyRent, unitRequest.Occupancy);

            if (result.IsFailed)
            {
                var error = result.Errors.First();

                return error switch
                {
                    EntityNotFoundError => NotFound(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Created($"api/units/{result.Value.Id}", result.Value);
        }

        [HttpGet]
        public async Task<ActionResult<List<UnitResponse>>> GetAllUnitsAsync()
        {
            var units = await _unitQueries.GetUnitsAsync();
            
            if(units.Count == 0)
            {
                return NotFound("No units found.");
            }

            return Ok(units);
        }
    }
}
