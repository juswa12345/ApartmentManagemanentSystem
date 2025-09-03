using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.Repositories
{
    public interface IOwnerRepository
    {
        Task<Owner?> GetOwnerByIdAsync(OwnerId id);

        Task AddOwnerAsync(Owner owner);
    }
}
