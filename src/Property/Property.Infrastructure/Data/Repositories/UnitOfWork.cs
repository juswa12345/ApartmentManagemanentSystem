using Property.Application.Repositories;

namespace Property.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOwnershipRespository _ownershipRespository;
        private readonly PropertyDBContext _context;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUnitReposirtory _unitRepository;
        private readonly IOwnerRespository _ownerRepository;

        public UnitOfWork(IOwnershipRespository ownershipRespository, PropertyDBContext context, IBuildingRepository buildingRepository, IUnitReposirtory unitRepository, IOwnerRespository ownerRepository)
        {
            _ownershipRespository = ownershipRespository;
            _context = context;
            _buildingRepository = buildingRepository;
            _unitRepository = unitRepository;
            _ownerRepository = ownerRepository;
        }

        public IBuildingRepository BuildingRepository => _buildingRepository;

        public IUnitReposirtory UnitReposirtory => _unitRepository;

        public IOwnerRespository OwnerRepository => _ownerRepository;

        public IOwnershipRespository OwnershipRepository => _ownershipRespository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
