using Property.Application.Response;

namespace Property.Application.Commnds
{
    public interface IPropertyOwnershipCommands
    {
        Task CreateOwnership(Guid ownerId, Guid unitId);

        Task<List<OwnershipResponse>> GetOwnershipsAsync();
    }
}
