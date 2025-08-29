namespace Leasing.Application.Repositories
{
    public interface IUnitOfWork
    {
        IBuildingRepository BuildingRepository { get; }

        IUnitReposirtory UnitReposirtory { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
