using AutoMapper;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Leasing.Infrastructure.QueryHandler
{
    public class BuildingQueries : IBuildingQueries
    {
        private readonly LeasingDBContext _context;
        private readonly IMapper _mapper;

        public BuildingQueries(LeasingDBContext context, IMapper mapper)
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
