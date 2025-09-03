using AutoMapper;
using FluentResults;
using Leasing.Application.Commands;
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

        public async Task AddUnitAsync(Guid Id, string buildingName, string unitNumber, int floor, double monthlyRent, int occupancy)
        {

            var unit = Unit.Create(new UnitId(Id), buildingName, unitNumber, floor, monthlyRent, occupancy);

            await _unitOfWork.UnitReposirtory.AddUnitAsync(unit);
            await _unitOfWork.SaveChangesAsync(default);
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
