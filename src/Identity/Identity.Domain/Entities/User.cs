using ApartmentManagementSystem.SharedKernel.Entities;
using Identity.Domain.ValueObjects;

namespace Identity.Domain.Entities
{
    public class User : Entity
    {
        public UserId Id { get; set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }


        private User(UserId id, string fullName, string email, string passwordHash)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
        }

        //factory method to create a new user
        public static User Create(string firstname, string lastName, string email, string passwordHash)
        {
            string fullName = $"{firstname} {lastName}";

            var user = new User(new UserId(Guid.NewGuid()), fullName, email, passwordHash);
            //user.RaiseDomainEvent(new UserCreatedEvent(user));

            return user;
        }


        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
        }

        public void Update(string newFirstName, string newLastName)
        {
            if (string.IsNullOrWhiteSpace(newFirstName))
            {
                throw new ArgumentException("Name  cannot be empty", nameof(newFirstName));
            }

            if (string.IsNullOrWhiteSpace(newLastName))
            {
                throw new ArgumentException("LastName  cannot be empty", nameof(newLastName));
            }
            FullName = $"{newFirstName} {newLastName}";
        }
    }
}
