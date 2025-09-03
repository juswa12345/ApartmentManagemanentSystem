using Property.Domain.Entities;

namespace Property.Application.Repositories
{
    public interface IOwnershipRespository
    {
        Task AddOwnershipAsync(PropertyOwnership ownership);

        Task<List<PropertyOwnership>> GetPropertyOwnershipsAsync();
    }
}
