using Property.Application.Commnds;
using Property.Application.Repositories;
using Property.Domain.Entities;
using Property.Domain.Enums;
using Property.Domain.ValueObjects;

namespace Property.Application.CommandHandlers
{
    public class OwnerCommands : IOwnerCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddOwnerAsync(Guid id, string firstName, string lastName, string email, string contactNumber, int gender, int age, string street, string city, string state, string zipCode)
        {
            Gender selectedGender = gender switch
            {
                0 => Gender.Male,
                1 => Gender.Female,
                2 => Gender.Other,
                _ => throw new ArgumentOutOfRangeException(nameof(gender)),
            };

            var owner = Owner.Create(new PersonName(firstName, lastName), new Address(street, city, state, zipCode), email, contactNumber, age, selectedGender);

            await _unitOfWork.OwnerRepository.AddOwnerAsync(owner);
            await _unitOfWork.SaveChangesAsync(default);
        }
    }
}
