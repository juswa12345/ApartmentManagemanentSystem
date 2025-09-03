using Microsoft.EntityFrameworkCore;
using Property.Application.Repositories;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly PropertyDBContext _context;

        public BuildingRepository(PropertyDBContext context)
        {
            _context = context;
        }

        public async Task  AddBuildingAsync(Building building)
        {
            await _context.Buildings.AddAsync(building);
        }

        public Task DeleteBuildingAsync(Building building)
        {
            _context.Buildings.Remove(building);

            return Task.CompletedTask;
        }

        public async Task<Building?> GetBuildingByIdAsync(BuildingId buildingId)
        {
            var building = await _context.Buildings.Include(b => b.Units).FirstOrDefaultAsync();

            return building;
        }

        public Task UpdateBuildingAsync(Building building)
        {
            _context.Buildings.Update(building);

            return Task.CompletedTask;
        }
    }
}
