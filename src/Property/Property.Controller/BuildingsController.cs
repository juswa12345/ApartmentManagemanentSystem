using Property.Application.Commnds;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Controller.Request;
using Microsoft.AspNetCore.Mvc;

namespace Property.Controller
{
    [Route("api/buildings")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingCommands _buildingCommands;
        private readonly IBuildingQueries _buildingQueries;

        public BuildingsController(IBuildingCommands buildingCommands, IBuildingQueries buildingQueries)
        {
            _buildingCommands = buildingCommands;
            _buildingQueries = buildingQueries;
        }

        [HttpPost] 
        public async Task<ActionResult<BuildingResponse>> AddNewBuildingAsync(BuildingRequest building)
        {
            var result = await _buildingCommands.AddBuildingAsync(building.BuildingName, building.BuildNumber, building.Street, building.City, building.State, building.ZipCode, building.NumberOfFloors, building.YearBuilt);


            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingResponse>> GetBuildingByIdAsync(Guid id)
        {
            var building = await _buildingCommands.GetBuildingByIdAsync(id);

            if (building is null)
                return NotFound();

            return Ok(building);
        }

        [HttpGet]
        public async Task<ActionResult<List<BuildingResponse>>> GetBuildings(Guid id)
        {
            var buildings = await _buildingCommands.GetBuildingsAsync();

            if (buildings.Count == 0)
                return NoContent();

            return Ok(buildings);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateBuildingAsync(Guid id, UpdateBuildingRequest building)
        {
            await _buildingCommands.UpdateBuildingAsync(id, building.BuildingName, building.Street, building.City, building.State, building.ZipCode, building.NumberOfFloors, building.YearBuilt, building.notes);

            return Ok();
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteBuildingAsync(Guid id)
        {
            await _buildingCommands.DeleteBuildingAsync(id, default);

            return Ok();
        }
    }
}
