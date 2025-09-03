namespace Leasing.Application.Response
{
    public class UnitResponse
    {

        public Guid Id { get;  set; }

        public string BuildingName { get; set; } = null!;

        public string UnitNumber { get; set; } = null!;
        public int Floor { get;  set; }
        public int Status { get;  set; }
        public double? MonthlyRent { get;  set; }
        public int? OccupancyLimit { get;  set; }

    }

}
