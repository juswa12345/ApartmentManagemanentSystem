using Identity.Domain.Repositories;

namespace Identity.Application.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IAccountRepository AccountRepository { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
