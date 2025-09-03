using ApartmentManagementSystem.SharedKernel.Enums;

namespace Leasing.Application.Commands
{
    public interface IOwnerCommands
    {
        Task AddOwnerAsync(Guid id, string firstName, string lastName, string email, string contactNumber);
    }
}
