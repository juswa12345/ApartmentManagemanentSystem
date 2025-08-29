using Leasing.Application.Repositories;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly LeasingDBContext _context;

        public BuildingRepository(LeasingDBContext context)
        {
            _context = context;
        }

        public async Task  AddBuildingAsync(Building building)
        {
            await _context.Buildings.AddAsync(building);
        }

        public async Task DeleteBuildingAsync(Building building)
        {
            _context.Buildings.Remove(building);
        }

        public async Task<Building?> GetBuildingByIdAsync(BuildingId buildingId)
        {
            var building = await _context.Buildings.Include(b => b.Units).FirstOrDefaultAsync();

            return building;
        }
    }
}
