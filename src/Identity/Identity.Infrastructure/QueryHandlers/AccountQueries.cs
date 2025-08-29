using Identity.Application.Queries;
using Identity.Domain.Entities;
using Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.QueryHandlers
{
    public class AccountQueries : IAccountQueries
    {
        private readonly IdentityDbContext _context;

        public AccountQueries(IdentityDbContext context)
        {
            _context = context;
        }
        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _context.Accounts.Include(a => a.User).ToListAsync();
        }
    }
}
