using ApartmentManagementSystem.SharedKernel.Enums;
using ApartmentManagementSystem.SharedKernel.ValueObjects;
using AutoMapper;
using Property.Application.Commnds;
using Property.Application.Queries;
using Property.Application.Repositories;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Application.CommandHandlers
{
    public class OwnerCommands : IOwnerCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOwnerQueries _ownerQueries;

        public OwnerCommands(IUnitOfWork unitOfWork, IMapper mapper, IOwnerQueries ownerQueries)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ownerQueries = ownerQueries;
        }
        public async Task AddOwnerAsync(Guid id, string firstName, string lastName, string email, string contactNumber, Gender gender, int age, string street, string city, string state, string zipCode)
        {
            var owner = Owner.Create(new PersonName(firstName, lastName), new Address(street, city, state, zipCode), email, contactNumber, age, gender);

            await _unitOfWork.OwnerRepository.AddOwnerAsync(owner);
            await _unitOfWork.SaveChangesAsync(default);
        }

        public async Task DeleteOwnerAsync(Guid id)
        {
            var owner = await _unitOfWork.OwnerRepository.GetOwnerByIdAsync(new OwnerId(id));

            if (owner is null)
                throw new Exception("Owner not found");

            await _unitOfWork.OwnerRepository.DeleteOwnerAync(owner);
            await _unitOfWork.SaveChangesAsync(default);
        }

        public async Task<OwnerReponse?> GetOwnerByIdAsync(Guid id)
        {
            var owner = await _unitOfWork.OwnerRepository.GetOwnerByIdAsync(new OwnerId(id));

            if(owner is null)
                return null;

            return _mapper.Map<OwnerReponse>(owner);
        }

        public async Task<List<OwnerReponse>> GetOwnersAsync()
        {
            var owners = await _ownerQueries.GetOwnersAsync();

            if(owners.Count == 0)
                return [];

            return _mapper.Map<List<OwnerReponse>>(owners);
        }

        public async Task UpdateOwnerAsync(Guid id, string firstName, string lastName, string email, string contactNumber, int age, string street, string city, string state, string zipCode)
        {


            var owner = await _unitOfWork.OwnerRepository.GetOwnerByIdAsync(new OwnerId(id));

            if(owner is null)
                throw new Exception("Owner not found");

            var updatedFirstName = firstName == "" ? owner.FullName.FirstName : firstName;
            var updatedLastName = lastName == "" ? owner.FullName.LastName : lastName;


            string updatedStreet = street == "" ? owner.Address.Street : street;
            string updatedCity = city == "" ? owner.Address.City : city;
            string updatedState = state == "" ? owner.Address.Street : state;
            string updatedZipcode = zipCode == "" ? owner.Address.ZipCode : zipCode;

            owner.UpdateDetails(new PersonName(updatedFirstName, updatedLastName), new Address(updatedStreet, updatedCity, updatedState, updatedZipcode), email, contactNumber, age);

            await _unitOfWork.OwnerRepository.UpdateOwnerAsync(owner);

            await _unitOfWork.SaveChangesAsync(default);

        }
    }
}
