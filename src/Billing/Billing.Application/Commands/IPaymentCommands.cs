using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Application.Commands
{
    public interface IPaymentCommands
    {
        Task ProcessPaymentAsync(Guid tenantId, Guid unitId, decimal amount);
    }
}
