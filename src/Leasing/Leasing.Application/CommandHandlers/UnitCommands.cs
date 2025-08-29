using AutoMapper;
using FluentResults;
using Leasing.Application.Commnds;
using Leasing.Application.Errors;
using Leasing.Application.Repositories;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.CommandHandlers
{
    internal class UnitCommands : IUnitCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            return Result.Ok(_mapper.Map<UnitResponse>(unit));
        }

        public async Task DeleteUnitAsync(Guid id, CancellationToken cancellationToken)
        {
            var unit = await _unitOfWork.UnitReposirtory.GetUnitByIdAsync(new UnitId(id));

            if(unit is not null)
                await _unitOfWork.UnitReposirtory.DeleteUnitAsync(unit);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public Task<Unit> UpdateUnitAsync(Guid id, string buildingName, string street, string city, string state, string zip, int numberOfFloors, int yearBuilt, string? notes)
        {
            throw new NotImplementedException();
        }
    }
}
