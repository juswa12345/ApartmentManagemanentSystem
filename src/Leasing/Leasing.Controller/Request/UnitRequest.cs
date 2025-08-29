namespace Leasing.Controller.Request
{
    public class UnitRequest
    {
        public string UnitNumber { get; set; }
        public int Floor { get; set; }
        public double MonthlyRent { get; set; }
        public int Occupancy { get; set; }
    }
}
