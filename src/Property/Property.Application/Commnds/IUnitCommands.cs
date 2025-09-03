using FluentResults;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Application.Commnds
{
    public interface IUnitCommands
    {
        Task<Result<UnitResponse>> AddUnitAsync(Guid id, string unitNumber, int floor, double monthlyRent, int occupancy);

        Task DeleteUnitAsync(Guid id, CancellationToken cancellationToken);

        Task <List<UnitResponse>> GetUnitsAsync();

        Task<UnitResponse> GetUnitAsync(Guid id);

        Task UpdateUnitAsync(Guid id, string unitNumber, int floor, int capacity, double monthlyRent);
    }
}
