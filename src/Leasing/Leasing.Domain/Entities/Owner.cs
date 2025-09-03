using ApartmentManagementSystem.SharedKernel.ValueObjects;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Owner
    {
        public OwnerId Id { get; set; }
        public PersonName OwnerName { get; set; } = default!;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        private Owner(OwnerId id, string phoneNumber, string email)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            Email = email;
        }


        public static Owner Create(
           OwnerId id,
           PersonName ownerName,
           string phoneNumber,
           string email)
        {
            var owner = new Owner(id, phoneNumber, email)
            {
                OwnerName = ownerName
            };


            return owner;
        }
    }
}
