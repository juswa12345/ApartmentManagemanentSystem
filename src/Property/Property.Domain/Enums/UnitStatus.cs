namespace Property.Domain.Enums
{
    public enum UnitStatus
    {
        Vacant = 0,
        Occupied = 1,
        Maintenance = 2,
        Reserved = 3 

    }

    public static class UnitStatusExtensions
    {
        public static UnitStatus ToUnitStatus(this int value)
        {
            if (Enum.IsDefined(typeof(UnitStatus), value))
            {
                return (UnitStatus)value;
            }

            throw new ArgumentException($"Invalid value for UnitStatus: {value}");
        }
    }
}
