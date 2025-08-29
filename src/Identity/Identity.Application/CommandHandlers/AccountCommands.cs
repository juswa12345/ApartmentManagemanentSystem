using ApartmentManagementSystem.Contracts.Services;
using AutoMapper;
using Identity.Application.Commands;
using Identity.Application.Queries;
using Identity.Application.Repositories;
using Identity.Application.Response;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Identity.Domain.ValueObjects;

namespace Identity.Application.CommandHandlers
{
    public class AccountCommands : IAccountCommands
    {
        private readonly IDomainEventPublisher _publisher;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IAccountQueries _accountQueries;

        public AccountCommands(IDomainEventPublisher publisher, IAccountRepository accountRepository, IMapper mapper, IRoleRepository roleRepository, IAccountQueries accountQueries)
        {
            _publisher = publisher;
            _accountRepository = accountRepository;
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


            var tenant = Account.Create(new UserId(userId), new PersonName(firstName, lastName), new Address(street, city, state, zipCode), email, contactNumber,  age, selectedGender);

            await _accountRepository.AddTenantAsync(tenant);
            await _accountRepository.SaveChangesAsync(default);
            
            await _publisher.PublishAsync(tenant.DomainEvents, default);
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
