using ApartmentManagementSystem.SharedKernel.ValueObjects;
using Leasing.Application.Commands;
using Leasing.Application.Repositories;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.CommandHandlers
{
    public class OwnerCommands : IOwnerCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddOwnerAsync(Guid id, string firstName, string lastName, string email, string contactNumber)
        {
            var owner = Owner.Create(new OwnerId(id), new PersonName(firstName, lastName), email, contactNumber);

            await _unitOfWork.OwnerRepository.AddOwnerAsync(owner);
            await _unitOfWork.SaveChangesAsync(default);
        }
    }
}
