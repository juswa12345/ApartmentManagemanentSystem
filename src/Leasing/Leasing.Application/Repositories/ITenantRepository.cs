using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.Repositories
{
    public interface ITenantRepository
    {
        Task AddTenantAsync(Tenant tenant);
        Task <Tenant?> GetTenantByIdAsync(TenantId tenantId);
        Task UpdateTenantAsync(Tenant tenant);
        Task DeleteTenantAsync(Tenant tenant);

    }
}
