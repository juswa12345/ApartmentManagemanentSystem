namespace Leasing.Application.Response
{
    public class TenantReponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public List<LeaseResponse> Contracts { get; set; }
    }

    public class LeaseResponse 
    {
        public string unitId { get; set; }
        public string UnitNumber { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
