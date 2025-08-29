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
            var building = await _buildingQueries.GetBuildingByIdAsync(id);

            if (building is null)
                return NotFound();

            return Ok(building);
        }

        [HttpGet]
        public async Task<ActionResult<List<BuildingResponse>>> GetBuildings(Guid id)
        {
            var buildings = await _buildingQueries.GetBuildingsAsync();

            if (buildings.Count == 0)
                return NoContent();

            return Ok(buildings);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BuildingResponse>> UpdateBuildingAsync(Guid id, UpdateBuildingRequest building)
        {
            var result = await _buildingCommands.UpdateBuildingAsync(id, building.BuildingName, building.Street, building.City, building.State, building.ZipCode, building.NumberOfFloors, building.YearBuilt, building.notes);

            if(result == null) 
                return NotFound();


            var newBuilding = await _buildingQueries.UpdateBuildAsync(result);

            if (newBuilding == null)
                return NotFound();

            return Ok(newBuilding);
        }

    }
}
