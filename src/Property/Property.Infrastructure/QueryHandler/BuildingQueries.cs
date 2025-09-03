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

        public BuildingQueries(PropertyDBContext context)
        {
            _context = context;
        }
        public async Task<Building?> GetBuildingByIdAsync(Guid id)
        {
            return await _context.Buildings.Where(b => b.Id == new BuildingId(id)).Include(b => b.Units).FirstOrDefaultAsync();
        }

        public async Task<List<Building>> GetBuildingsAsync()
        {
            var buildings = await _context.Buildings.Include(b => b.Units).ToListAsync();

            if (buildings.Count <= 0)
                return [];

            return buildings;
        }
    }
}
