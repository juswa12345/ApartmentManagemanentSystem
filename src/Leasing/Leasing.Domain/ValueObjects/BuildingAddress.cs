using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Domain.ValueObjects
{
    public record BuildingAddress(string Street, string City, string State, string ZipCode);
}
