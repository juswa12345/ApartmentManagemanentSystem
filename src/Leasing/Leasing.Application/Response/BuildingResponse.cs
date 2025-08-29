namespace Leasing.Application.Response
{
    public class BuildingResponse
    {

        public Guid Id { get; set; }
        public string BuildingNumber { get; set; }
        public string Name { get; private set; }
        public string BuildingAddress { get; set; } = default!;
        public int NumberOfFloors { get; set; }
        public int YearBuilt { get;  set; }
        public List<UnitsResponse> Units { get; set; } = [];
    }

    public class UnitsResponse
    {
        public string Id { get; set; }

        public string UnitNumber { get; set; }

        public int FloorNumber { get; set; }

        public int Status { get; set; }
    }
}
