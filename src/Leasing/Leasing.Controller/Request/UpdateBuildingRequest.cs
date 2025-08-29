using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Controller.Request
{
    public class UpdateBuildingRequest
    {
        public string BuildingName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int NumberOfFloors { get; set; }
        public int YearBuilt { get; set; }
        public string? notes { get; set; }

    }
}
