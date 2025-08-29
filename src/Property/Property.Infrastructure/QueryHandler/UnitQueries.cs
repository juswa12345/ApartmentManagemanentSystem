using AutoMapper;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Property.Infrastructure.QueryHandler
{
    public class UnitQueries : IUnitQueries
    {
        private readonly PropertyDBContext _context;
        private readonly IMapper _mapper;

        public UnitQueries(PropertyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UnitResponse> GetUnitByIdAsync(Guid id)
        {
            var unit = await _context.Units.Include(b => b.Building).FirstOrDefaultAsync();

            return _mapper.Map<UnitResponse>(unit);
        }

        public async Task<List<UnitResponse>> GetUnitsAsync()
        {
            var units = await _context.Units.Include(b => b.Building).Include(b => b.Owner).ToListAsync();

            if (units.Count <= 0)
                return [];

            return _mapper.Map<List<UnitResponse>>(units);
        }
    }
}
