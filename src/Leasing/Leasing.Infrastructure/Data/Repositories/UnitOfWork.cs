using Leasing.Application.Repositories;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeasingDBContext _context;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUnitReposirtory _unitRepository;

        public UnitOfWork(LeasingDBContext context, IBuildingRepository buildingRepository, IUnitReposirtory unitRepository)
        {
            _context = context;
            _buildingRepository = buildingRepository;
            _unitRepository = unitRepository;
        }

        public IBuildingRepository BuildingRepository => _buildingRepository;

        public IUnitReposirtory UnitReposirtory => _unitRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
