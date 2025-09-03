using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface ITenantCommands
    {
        Task AddTenantAsync(Guid tenantId, string firstName, string lastName, string email, string phoneNumber);
        Task RemoveTenantAsync(Guid tenantId);
        Task UpdateTenantAsync(Guid tenantId, string firstName, string lastName, string email, string phoneNumber);
        Task <TenantReponse?> GetTenantByIdAsync(Guid tenantId);
        Task<List<TenantReponse>> GetAllTenantsAsync();

    }
}
