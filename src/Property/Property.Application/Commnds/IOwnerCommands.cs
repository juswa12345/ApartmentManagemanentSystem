using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Commnds
{
    public interface IOwnerCommands
    {
        Task AddOwnerAsync(Guid id, string firstName, string lastName, string email, string contactNumber, int gender, int age, string street, string city, string state, string zipCode);
    }
}
