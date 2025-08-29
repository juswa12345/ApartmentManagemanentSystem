using Property.Application.Repositories;

namespace Property.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PropertyDBContext _context;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUnitReposirtory _unitRepository;
       private readonly IOwnerRepository _ownerRepository;

        public UnitOfWork(PropertyDBContext context, IBuildingRepository buildingRepository, IUnitReposirtory unitRepository, IOwnerRepository ownerRepository)
        {
            _context = context;
            _buildingRepository = buildingRepository;
            _unitRepository = unitRepository;
            _ownerRepository = ownerRepository;
        }

        public IBuildingRepository BuildingRepository => _buildingRepository;

        public IUnitReposirtory UnitReposirtory => _unitRepository;

        public IOwnerRepository OwnerRepository => _ownerRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
