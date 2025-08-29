using Property.Domain.Enums;
using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
{
    public class Owner
    {
        public OwnerId Id { get; set; }
        public PersonName FullName { get; private set; } = default!;
        public Address Address { get; private set; } = default!;
        public Gender Gender { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public string ContactNumber { get; private set; }
        public DateTimeOffset? CreatedAt { get; private set; }
        public DateTimeOffset? UpdatedAt { get; private set; }
        public List<Unit> Units { get; private set; } = [];

        private Owner(OwnerId id,string email, string contactNumber, int age) 
        {
            Id = id;
            Email = email;
            ContactNumber = contactNumber;
            CreatedAt = DateTimeOffset.UtcNow;
            Age = age;
        }


        public static Owner Create(
           PersonName fullName,
           Address address,
           string email,
           string contactNumber,
           int age,
           Gender gender)
        {
            return new Owner(new OwnerId(Guid.NewGuid()), email, contactNumber, age)
            {
                Gender = gender, FullName = fullName, Address = address
            };
        }
        
    }
}
