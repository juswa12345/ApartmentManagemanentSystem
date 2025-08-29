using Identity.Domain.Entities;

namespace Identity.Application.Repositories
{
    public interface IAccountRepository
    {
        Task AddTenantAsync(Account tenant);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
