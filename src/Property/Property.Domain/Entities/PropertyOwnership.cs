using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
{
    public class PropertyOwnership
    {
        public PropertyOwnershipId Id { get; set; }
        public OwnerId OwnerId { get; set; }
        public Owner Owner { get; set; } = null!;
        public UnitId UnitId { get; set; }
        public Unit Unit { get; set; } = null!;
        public DateTimeOffset DateOwned { get; set; }


        private PropertyOwnership(
            PropertyOwnershipId id,
            OwnerId ownerId,
            UnitId unitId,
            DateTimeOffset dateOwned)
        {
            Id = id;
            OwnerId = ownerId;
            UnitId = unitId;
            DateOwned = dateOwned;
        }
        

        public static PropertyOwnership Create(OwnerId ownerId, UnitId unitId, DateTimeOffset dateOwned)
        {
            return new PropertyOwnership(
                new PropertyOwnershipId(Guid.NewGuid()),
                ownerId,
                unitId,
                dateOwned);
        }
    }
}
