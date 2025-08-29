using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
{
    public class Building
    {
        public BuildingId Id { get; set; }
        public string BuildingNumber { get; set; }
        public string Name { get; private set; }
        public BuildingAddress BuildingAddress { get; set; } = default!;
        public int NumberOfFloors { get; set; }
        public int YearBuilt { get; private set; }
        public string? Notes { get; private set; }
        public DateTimeOffset? CreatedAt { get; private set; } 
        public DateTimeOffset? UpdatedAt { get; private set; }

        public List<Unit> Units { get; set; } = [];

        private Building(BuildingId id, string name, string buildingNumber, int numberOfFloors, int yearBuilt, string? notes = null)
        {
            Id = id;
            Name = name;
            BuildingNumber = buildingNumber;
            NumberOfFloors = numberOfFloors;
            YearBuilt = yearBuilt < 1800 || yearBuilt > DateTime.UtcNow.Year + 1 ? throw new ArgumentOutOfRangeException(nameof(yearBuilt)) : yearBuilt;
            Notes = notes;
        }

        public static Building Create(string name, string buildingNumber, BuildingAddress address, int numberOfFloors, int yearBuilt, string? notes = null)
        {
            var building = new Building(new BuildingId(Guid.NewGuid()), name, buildingNumber, numberOfFloors, yearBuilt, notes)
            {
                CreatedAt = DateTimeOffset.UtcNow,
                BuildingAddress = address
            };

            return building;
        }

        public void Update(string name, BuildingAddress address, int numberOfFloors, int yearBuilt, string? notes = null)
        {
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Name is required.") : name.Trim();
            BuildingAddress = address ?? throw new ArgumentNullException(nameof(address));
            NumberOfFloors = numberOfFloors <= 0 ? throw new ArgumentOutOfRangeException(nameof(numberOfFloors)) : numberOfFloors;
            YearBuilt = yearBuilt < 1800 || yearBuilt > DateTime.UtcNow.Year + 1 ? throw new ArgumentOutOfRangeException(nameof(yearBuilt)) : yearBuilt;
            Notes = string.IsNullOrWhiteSpace(notes) ? null : notes.Trim();
            Touch();
        }

        public void Touch() => UpdatedAt = DateTimeOffset.UtcNow;
    }
}
