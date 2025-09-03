using Leasing.Application.Repositories;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly LeasingDBContext _leasingDBContext;

        public TenantRepository(LeasingDBContext leasingDBContext)
        {
            _leasingDBContext = leasingDBContext;
        }
        public async Task AddTenantAsync(Tenant tenant)
        {
            await _leasingDBContext.Tenants.AddAsync(tenant);
        }

        public Task DeleteTenantAsync(Tenant tenant)
        {
            _leasingDBContext.Tenants.Remove(tenant);

            return Task.CompletedTask;
        }

        public Task<Tenant?> GetTenantByIdAsync(TenantId tenantId)
        {
            return _leasingDBContext.Tenants.Where(t => t.Id == tenantId).Include(t => t.LeaseRecords).ThenInclude(l => l.Unit).FirstOrDefaultAsync();
        }

        public Task UpdateTenantAsync(Tenant tenant)
        {
            _leasingDBContext.Tenants.Update(tenant);

            return Task.CompletedTask;
        }
    }
}
