using ApartmentManagementSystem.Contracts.Services;
using AutoMapper;
using FluentResults;
using Property.Application.Commnds;
using Property.Application.Errors;
using Property.Application.Queries;
using Property.Application.Repositories;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Application.CommandHandlers
{
    internal class UnitCommands : IUnitCommands
    {
        private readonly IDomainEventPublisher _publisher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUnitQueries _unitQueries;

        public UnitCommands(IDomainEventPublisher publisher, IUnitOfWork unitOfWork, IMapper mapper, IUnitQueries unitQueries)
        {
            _publisher = publisher;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _unitQueries = unitQueries;
        }

        public async Task<Result<UnitResponse>> AddUnitAsync(Guid id, string unitNumber, int floor, double monthlyRent, int occupancy)
        {
            var building = await _unitOfWork.BuildingRepository.GetBuildingByIdAsync(new BuildingId(id));

            if(building is null)
            {
                return Result.Fail(new EntityNotFoundError($"Build with ID: {id} is not Found"));
            }

            var unit = Unit.Create(building, unitNumber, floor, monthlyRent, occupancy);

            await _unitOfWork.UnitReposirtory.AddUnitAsync(unit);
            await _unitOfWork.SaveChangesAsync(default);

            await _publisher.PublishAsync(unit.DomainEvents, default);

            return Result.Ok(_mapper.Map<UnitResponse>(unit));
        }

        public async Task DeleteUnitAsync(Guid id, CancellationToken cancellationToken)
        {
            var unit = await _unitOfWork.UnitReposirtory.GetUnitByIdAsync(new UnitId(id));

            if(unit is not null)
                await _unitOfWork.UnitReposirtory.DeleteUnitAsync(unit);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<UnitResponse> GetUnitAsync(Guid id)
        {
            var unit = await _unitOfWork.UnitReposirtory.GetUnitByIdAsync(new UnitId(id));

            if (unit is null)
                throw new KeyNotFoundException($"Unit with ID: {id} is not Found");

            return _mapper.Map<UnitResponse>(unit);
        }

        public async Task<List<UnitResponse>> GetUnitsAsync()
        {
            var units = await _unitQueries.GetUnitsAsync();

            if (units.Count == 0)
                return [];

            return _mapper.Map<List<UnitResponse>>(units);
        }

        public async Task UpdateUnitAsync(Guid id, string unitNumber, int floor, int capacity, double monthlyRent)
        {
            var unit = await _unitOfWork.UnitReposirtory.GetUnitByIdAsync(new UnitId(id));

            if (unit is null)
                throw new KeyNotFoundException($"Unit with ID: {id} is not Found");

            unit.Update(unitNumber, floor, monthlyRent, capacity);

            await _unitOfWork.UnitReposirtory.UpdateUnitAsync(unit);

            await _unitOfWork.SaveChangesAsync(default);
        }
    }
}
