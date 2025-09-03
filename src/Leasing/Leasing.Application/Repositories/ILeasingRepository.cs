using Leasing.Domain.Entities;

namespace Leasing.Application.Repositories
{
    public interface ILeasingRepository
    {
        Task CreateLeaseAgreementAsync(LeasingRecord leasingRecord);
    }
}
