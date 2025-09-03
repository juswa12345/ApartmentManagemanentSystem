namespace Leasing.Domain.ValueObjects
{
    public record LeaseTerm
    {
        public DateTimeOffset Start { get; }
        public DateTimeOffset? End { get; }

        private LeaseTerm(DateTimeOffset start, DateTimeOffset? end)
        {
            if (end is not null && end < start)
                throw new Exception("Lease end cannot be before start.");
            Start = start;
            End = end;
        }

        public static LeaseTerm Create(DateTimeOffset start, DateTimeOffset? end) => new(start, end);

        public LeaseTerm WithEnd(DateTimeOffset end) => new(Start, end);
    }
}
