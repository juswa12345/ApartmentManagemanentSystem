using ApartmentManagementSystem.SharedKernel.ValueObjects;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Tenant
    {
        public TenantId Id { get; private set; }
        public PersonName TenantName { get; private  set; } = default!;
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public List<LeasingRecord> LeaseRecords { get; private set; } = [];

        private Tenant(TenantId id, string phoneNumber, string email)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    

        public static Tenant Create(
           TenantId id,
           PersonName tenantName,
           string phoneNumber,
           string email)
        {
            var tenant = new Tenant(id, phoneNumber, email)
            {
                TenantName = tenantName
            };


            return tenant;
        }


        public void Update(
           PersonName tenantName,
           string phoneNumber,
           string email)
        {
            TenantName = tenantName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
