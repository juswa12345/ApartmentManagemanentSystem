namespace Leasing.Application.Commands
{
    public interface ILeasingCommands
    {
        Task CreateLeaseAgreementAsync(Guid unitId, Guid tenantId, Guid ownerId, CancellationToken cancellationToken);
    }
}
