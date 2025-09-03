using Microsoft.EntityFrameworkCore;
using Property.Application.Queries;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;
using Property.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infrastructure.QueryHandler
{
    public class OwnerQueries : IOwnerQueries
    {
        private readonly PropertyDBContext _context;

        public OwnerQueries(PropertyDBContext context)
        {
            _context = context;
        }
        public async Task<Owner?> GetOwnerByIdAsync(Guid id)
        {
            return await _context.Owners.Where(o => o.Id == new OwnerId(id)).Include(o => o.PropertiesOwned).ThenInclude(p => p.Unit).FirstOrDefaultAsync();
        }

        public async Task<List<Owner>> GetOwnersAsync()
        {
            return await _context.Owners.Include(o => o.PropertiesOwned).ThenInclude(p => p.Unit).ToListAsync();
        }
    }
}
