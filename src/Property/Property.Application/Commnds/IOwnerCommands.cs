using ApartmentManagementSystem.SharedKernel.Enums;
using Property.Application.Response;

namespace Property.Application.Commnds
{
    public interface IOwnerCommands
    {
        Task AddOwnerAsync(Guid id, string firstName, string lastName, string email, string contactNumber, Gender gender, int age, string street, string city, string state, string zipCode);

        Task DeleteOwnerAsync(Guid id);

        Task<List<OwnerReponse>> GetOwnersAsync();

        Task<OwnerReponse?> GetOwnerByIdAsync(Guid id);

        Task UpdateOwnerAsync(Guid id, string firstName, string lastName, string email, string contactNumber, int age, string street, string city, string state, string zipCode);
    }
}
