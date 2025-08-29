using Property.Application.Repositories;

namespace Property.Application.Repositories
{
    public interface IUnitOfWork
    {
        IBuildingRepository BuildingRepository { get; }

        IUnitReposirtory UnitReposirtory { get; }

        IOwnerRepository OwnerRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
