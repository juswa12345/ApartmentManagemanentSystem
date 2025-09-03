using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Application.Commnds;
using Property.Application.Errors;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Controller.Request;

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
        public async Task<ActionResult<UnitResponse>> AddNewUnitAsync([FromQuery]Guid buildingId, [FromBody]UnitRequest unitRequest)
        {

            var result = await _unitCommands.AddUnitAsync(buildingId, unitRequest.UnitNumber, unitRequest.Floor, unitRequest.MonthlyRent, unitRequest.Occupancy);

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
            var units = await _unitCommands.GetUnitsAsync();
          
            return Ok(units);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<UnitResponse>> GetUnitByIdAsync([FromRoute] Guid id)
        {
            var unit = await _unitCommands.GetUnitAsync(id);

            return Ok(unit);
        }

        [HttpDelete("{id}/delete")]

        public async Task<ActionResult> DeleteUnitAsync([FromRoute] Guid id)
        {
            await _unitCommands.DeleteUnitAsync(id, default);

            return NoContent();
        }

        [HttpPut("{id}/update")]
        public async Task<ActionResult> UpdateUnitAsync([FromRoute] Guid id, [FromBody] UnitRequest unitRequest)
        {
            await _unitCommands.UpdateUnitAsync(id, unitRequest.UnitNumber, unitRequest.Floor,  unitRequest.Occupancy, unitRequest.MonthlyRent);
            
            return NoContent();
        }

    }
}
