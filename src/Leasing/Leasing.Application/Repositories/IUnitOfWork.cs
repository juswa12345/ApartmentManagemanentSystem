namespace Leasing.Application.Repositories
{
    public interface IUnitOfWork
    {
        IUnitReposirtory UnitReposirtory { get; }

        ITenantRepository TenantRepository { get; }

        IOwnerRepository OwnerRepository { get; }

        ILeasingRepository LeasingRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
