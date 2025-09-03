namespace Property.Application.Response
{
    public class OwnerReponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public List<PropertyReponse> UnitHistory { get; set; }
    }

    public class PropertyReponse
    {
        public Guid Id { get; set; }
        public OwnerUnitReposnse Unit { get; set; }
        public DateTimeOffset OwnedDate { get; set; }
    }

    public class OwnerUnitReposnse
    {
        public string UnitId { get; set; }
        public string UnitNumber { get; set; }
    }
}
