using AutoMapper;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.QueryHandler
{
    public class UnitQueries : IUnitQueries
    {
        private readonly LeasingDBContext _context;
        private readonly IMapper _mapper;

        public UnitQueries(LeasingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UnitResponse> GetUnitByIdAsync(Guid id)
        {
            var unit = await _context.Units.FirstOrDefaultAsync();

            return _mapper.Map<UnitResponse>(unit);
        }

        public async Task<List<UnitResponse>> GetUnitsAsync()
        {
            var units = await _context.Units.ToListAsync();

            if (units.Count <= 0)
                return [];

            return _mapper.Map<List<UnitResponse>>(units);
        }
    }
}
