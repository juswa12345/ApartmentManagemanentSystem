using Identity.Application.Repositories;
using Identity.Domain.Entities;

namespace Identity.Infrastructure.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IdentityDbContext _context;

        public AccountRepository(IdentityDbContext context)
        {
            _context = context;
        }
        public async Task AddTenantAsync(Account tenant)
        {
            await _context.Accounts.AddAsync(tenant);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
