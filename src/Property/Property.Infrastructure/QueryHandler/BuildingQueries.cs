using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;
using Property.Infrastructure.Data;

namespace Property.Infrastructure.QueryHandler
{
    public class BuildingQueries : IBuildingQueries
    {
        private readonly PropertyDBContext _context;
        private readonly IMapper _mapper;

        public BuildingQueries(PropertyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BuildingResponse?> GetBuildingByIdAsync(Guid id)
        {
            var building = await _context.Buildings.Where(b => b.Id == new BuildingId(id)).Include(b => b.Units).FirstOrDefaultAsync();

            return _mapper.Map<BuildingResponse>(building);
        }

        public async Task<List<BuildingResponse>> GetBuildingsAsync()
        {
            var buildings = await _context.Buildings.Include(b => b.Units).ToListAsync();

            if (buildings.Count <= 0)
                return [];

            return _mapper.Map<List<BuildingResponse>>(buildings);
        }

        public async Task<BuildingResponse?> UpdateBuildAsync(Building building)
        {
            _context.Buildings.Update(building);

            await _context.SaveChangesAsync();

            var updatedBuilding = await _context.Buildings.Where(b => b.Id == building.Id).Include(b => b.Units).FirstOrDefaultAsync();

            return _mapper.Map<BuildingResponse>(updatedBuilding);
        }
    }
}
