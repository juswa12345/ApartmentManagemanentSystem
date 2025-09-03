using Leasing.Application.Repositories;
using Leasing.Domain.Entities;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class LeasingRepository : ILeasingRepository
    {
        private readonly LeasingDBContext _leasingDBContext;

        public LeasingRepository(LeasingDBContext leasingDBContext)
        {
            _leasingDBContext = leasingDBContext;
        }
        public async Task CreateLeaseAgreementAsync(LeasingRecord leasingRecord)
        {
            await _leasingDBContext.LeasingRecords.AddAsync(leasingRecord);
        }
    }
}
