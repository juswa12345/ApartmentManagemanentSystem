using Leasing.Application.Queries;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.QueryHandler
{
    public class TenantQueries : ITenantQueries
    {
        private readonly LeasingDBContext _context;

        public TenantQueries(LeasingDBContext context)
        {
            _context = context;
        }
        public async Task<Tenant?> GetTenantByIdAsync(Guid id)
        {
            var tenant = await _context.Tenants.Where(t => t.Id == new TenantId(id)).Include(t => t.LeaseRecords).ThenInclude(l => l.Unit).FirstOrDefaultAsync();

            return tenant;
        }

        public async Task<List<Tenant>> GetTenantsAsync()
        {
            return await _context.Tenants.Include(t => t.LeaseRecords).ThenInclude(l => l.Unit).ToListAsync();
        }
    }
}
