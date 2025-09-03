using Identity.Application.Repositories;
using Identity.Domain.Repositories;

namespace Identity.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityDbContext _identityDbContext;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAccountRepository _accountRepository;

        public UnitOfWork(IdentityDbContext identityDbContext, IUserRepository userRepository, IRoleRepository roleRepository, IAccountRepository accountRepository) 
        {
            _identityDbContext = identityDbContext;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _accountRepository = accountRepository;
        }
        public IUserRepository UserRepository => _userRepository;

        public IRoleRepository RoleRepository => _roleRepository;

        public IAccountRepository AccountRepository => _accountRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _identityDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
