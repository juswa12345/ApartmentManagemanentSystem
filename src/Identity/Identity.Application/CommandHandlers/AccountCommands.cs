using ApartmentManagementSystem.Contracts.Services;
using ApartmentManagementSystem.SharedKernel.Enums;
using ApartmentManagementSystem.SharedKernel.ValueObjects;
using AutoMapper;
using Identity.Application.Commands;
using Identity.Application.Queries;
using Identity.Application.Repositories;
using Identity.Application.Response;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Identity.Domain.Repositories;
using Identity.Domain.ValueObjects;

namespace Identity.Application.CommandHandlers
{
    public class AccountCommands : IAccountCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainEventPublisher _publisher;

        private readonly IMapper _mapper;
        private readonly IAccountQueries _accountQueries;

        public AccountCommands(IUnitOfWork unitOfWork, IDomainEventPublisher publisher, IMapper mapper, IRoleRepository roleRepository, IAccountQueries accountQueries)
        {
            _unitOfWork = unitOfWork;
            _publisher = publisher;
            _mapper = mapper;
            _accountQueries = accountQueries;
        }
        public async Task CreateTenantAsync(string firstName, string lastName, string email, string contactNumber, int gender, int age, string street, string city, string state, string zipCode, Guid userId)
        {
            Gender selectedGender = gender switch
            {
                0 => Gender.Male,
                1 => Gender.Female,
                2 => Gender.Other,
                _ => throw new ArgumentOutOfRangeException(nameof(gender)),
            };

            var user = await _unitOfWork.UserRepository.GetByIdAsync(new UserId(userId));

            if (user is null)
                throw new Exception($"User with ID: {userId} not found.");

            var role = await _unitOfWork.RoleRepository.GetRoleByIdAsync(new Guid(user.Roles.First()));

            if (role is null)
                throw new Exception($"Role with ID: {user.Roles.First()} not found.");

            var account = role.Name switch
            {
                "Owner" => Account.CreateOwner(new UserId(userId), new PersonName(firstName, lastName), new Address(street, city, state, zipCode), email, contactNumber, age, selectedGender),
                "Admin" => Account.Create(new UserId(userId), new PersonName(firstName, lastName), new Address(street, city, state, zipCode), email, contactNumber, age, selectedGender),
                "Tenant" => Account.CreateTenant(new UserId(userId), new PersonName(firstName, lastName), new Address(street, city, state, zipCode), email, contactNumber, age, selectedGender),
                _ => throw new NotImplementedException(),
            };


            await _unitOfWork.AccountRepository.AddTenantAsync(account);
            await _unitOfWork.SaveChangesAsync(default);
            
            await _publisher.PublishAsync(account.DomainEvents, default);
        }

        public async Task<List<AccountResponse>> GetAccountsAsync()
        {
            var accounts = await _accountQueries.GetAccountsAsync();

            if (accounts.Count == 0)
                return [];

            return _mapper.Map<List<AccountResponse>>(accounts);
        }
    }
}
