using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Domain.ValueObjects
{
    public record PersonName(string FirstName, string LastName)
    {
        public string FullName => $"{FirstName} {LastName}";
    }
}
