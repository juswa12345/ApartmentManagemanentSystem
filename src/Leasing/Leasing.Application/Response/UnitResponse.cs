namespace Leasing.Application.Response
{
    public class UnitResponse
    {

        public Guid Id { get;  set; }

        public BuildingResp building { get; set; } = null!;

        public string UnitNumber { get;  set; }
        public int Floor { get;  set; }
        public int Status { get;  set; }
        public double? MonthlyRent { get;  set; }
        public int? OccupancyLimit { get;  set; }

    }

    public class BuildingResp
    {
        public string Id { get; set; }
        public string BuildingNumber { get; set; }
        public string BuildingName { get; set; }
    } 
}
