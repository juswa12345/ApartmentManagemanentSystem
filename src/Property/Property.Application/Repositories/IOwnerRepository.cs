using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Application.Repositories
{
    public interface IOwnerRespository
    {
        Task<Owner?> GetOwnerByIdAsync(OwnerId id);

        Task DeleteOwnerAync(Owner owner);

        Task UpdateOwnerAsync(Owner owner);

        Task AddOwnerAsync(Owner owner);
    }
}
