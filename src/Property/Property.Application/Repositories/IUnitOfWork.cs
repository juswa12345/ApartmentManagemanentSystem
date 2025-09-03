using Property.Application.Repositories;

namespace Property.Application.Repositories
{
    public interface IUnitOfWork
    {
        IBuildingRepository BuildingRepository { get; }

        IUnitReposirtory UnitReposirtory { get; }

        IOwnerRespository OwnerRepository { get; }

        IOwnershipRespository OwnershipRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
