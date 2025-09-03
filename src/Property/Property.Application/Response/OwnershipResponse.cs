namespace Property.Application.Response
{
    public class OwnershipResponse
    {
        public Guid Id { get; set; }
        public OwnerDetailsResponse Owner { get; set; }
        public UnitOwnershipResponse Unit { get; set; }
        public DateTimeOffset OwnedDate { get; set; }
    }

    public class UnitOwnershipResponse
    {
        public string UnitId { get; set; }
        public string UnitNumber { get; set; }
    }

    public class OwnerDetailsResponse
    {
        public string OwnerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
