using Leasing.Domain.Entities;

namespace Leasing.Application.Queries
{
    public interface ITenantQueries
    {
        Task<List<Tenant>> GetTenantsAsync();
        Task<Tenant?> GetTenantByIdAsync(Guid id);
    }
}
