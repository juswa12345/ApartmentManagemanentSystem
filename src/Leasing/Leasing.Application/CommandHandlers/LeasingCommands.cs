using ApartmentManagementSystem.Contracts.Services;
using ApartmentManagementSystem.SharedKernel.Enums;
using Leasing.Application.Commands;
using Leasing.Application.Repositories;
using Leasing.Domain.Entities;
using Leasing.Domain.Services;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.CommandHandlers
{
    public class LeasingCommands : ILeasingCommands
    {
        private readonly IDomainEventPublisher _publisher;
        private readonly IUnitOfWork _unitOfWork;


        public LeasingCommands(IDomainEventPublisher publisher, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _unitOfWork = unitOfWork;
        }
        public async Task CreateLeaseAgreementAsync(Guid unitId, Guid tenantId, Guid ownerId, CancellationToken cancellationToken)
        {
            Tenant? tenant = await _unitOfWork.TenantRepository.GetTenantByIdAsync(new TenantId(tenantId));

            if(tenant is null)
                throw new Exception("Tenant not found");

            Unit? unit = await _unitOfWork.UnitReposirtory.GetUnitByIdAsync(new UnitId(unitId));


            if (unit is null)
                throw new Exception("Unit not found");


            if (unit.Status == UnitStatus.Occupied)
                throw new Exception("Unit is already occupied");


            Owner? owner = await _unitOfWork.OwnerRepository.GetOwnerByIdAsync(new OwnerId(ownerId));

            if(owner is null) throw new Exception("Owner not found");

            var LeasingServices = new LeasingServices();

            LeasingRecord leasingRecord = LeasingServices.CreateLease(unit, tenant, owner);

            await _unitOfWork.LeasingRepository.CreateLeaseAgreementAsync(leasingRecord);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _publisher.PublishAsync(leasingRecord.DomainEvents, cancellationToken);
        }
    }
}
