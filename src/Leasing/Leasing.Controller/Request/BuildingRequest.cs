
namespace Leasing.Controller.Request
{
    public class BuildingRequest
    {
        public string BuildingName { get; set; }
        public string BuildNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int NumberOfFloors { get; set; }
        public int YearBuilt { get; set; }
    }
}
