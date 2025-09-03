using Property.Domain.Entities;

namespace Property.Application.Queries
{
    public interface IOwnerQueries
    {
        Task<List<Owner>> GetOwnersAsync();
        Task<Owner?> GetOwnerByIdAsync(Guid id);
    }
}
