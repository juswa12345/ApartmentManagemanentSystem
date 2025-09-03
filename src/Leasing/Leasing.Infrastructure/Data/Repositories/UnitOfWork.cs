using Leasing.Application.Repositories;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeasingDBContext _context;
        private readonly IUnitReposirtory _unitRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ILeasingRepository _leasingRepository;

        public UnitOfWork(ILeasingRepository leasingRepository, IOwnerRepository ownerRepository, ITenantRepository tenantRepository, LeasingDBContext context, IUnitReposirtory unitRepository)
        {
            _context = context;
            _unitRepository = unitRepository;
            _tenantRepository = tenantRepository;
            _ownerRepository = ownerRepository;
            _leasingRepository = leasingRepository;
        }


        public IUnitReposirtory UnitReposirtory => _unitRepository;

        public ITenantRepository TenantRepository => _tenantRepository;

        public IOwnerRepository OwnerRepository => _ownerRepository;

        public ILeasingRepository LeasingRepository => _leasingRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
