using ApartmentManagementSystem.SharedKernel.Entities;
using Identity.Domain.DomainEvents;
using Identity.Domain.Enums;
using Identity.Domain.ValueObjects;

namespace Identity.Domain.Entities
{
    public class Account : Entity
    {
        public AccountId Id { get; set; }
        public UserId UserId { get; private set; } = default!;
        public User User { get; private set; } = default!;
        public PersonName FullName { get; private set; } = default!;
        public Address Address { get; private set; } = default!;
        public Gender Gender { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public string ContactNumber { get; private set; }
        public DateTimeOffset? CreatedAt { get; private set; }
        public DateTimeOffset? UpdatedAt { get; private set; }


        private Account(AccountId id, string email, string contactNumber, int age)
        {
            Id = id;
            Email = email;
            ContactNumber = contactNumber;
            CreatedAt = DateTimeOffset.UtcNow;
            Age = age;
        }

        public static Account Create(
            UserId userId,
            PersonName fullName,
            Address address,
            string email,
            string contactNumber, 
            int age,
            Gender gender)
        {

            var account = new Account(new AccountId(Guid.NewGuid()), email, contactNumber, age)
            {
                FullName = fullName,
                Address = address,
                Gender = gender,
                UserId = userId
            };

            account.RaiseDomainEvent(new UserCreatedEvent(account));

            return account;
        }

        public void Update(
            PersonName fullName,
            Address address,
            string email,
            string contactNumber)
        {
            
            Email = email;
            FullName = fullName;
            Address = address;
            ContactNumber = contactNumber;
            Touch();            
        }


        private void Touch() => UpdatedAt = DateTimeOffset.UtcNow;
    }
}
