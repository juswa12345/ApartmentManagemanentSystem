using Property.Domain.Entities;

namespace Property.Domain.Services
{
    public class OwnershipServices
    {
        public PropertyOwnership AddOwnership(Owner owner, Unit unit)
        {
            return PropertyOwnership.Create(owner.Id, unit.Id, DateTimeOffset.UtcNow);
        }
    }
}
