using ApartmentManagementSystem.SharedKernel.ValueObjects;
using AutoMapper;
using Property.Application.Commnds;
using Property.Application.Queries;
using Property.Application.Repositories;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Application.CommandHandlers
{
    public class BuildingCommands : IBuildingCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBuildingQueries _buildingQueries;

        public BuildingCommands(IUnitOfWork unitOfWork, IMapper mapper , IBuildingQueries buildingQueries)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _buildingQueries = buildingQueries;
        }

        public async Task<BuildingResponse> AddBuildingAsync(string buildingName, string buildingNumber, string street, string city, string state, string zip, int numberOfFloors, int yearBuilt)
        {
            var building = Building.Create(buildingName, buildingNumber, new Address(street, city, state, zip), numberOfFloors, yearBuilt);

            await _unitOfWork.BuildingRepository.AddBuildingAsync(building);
            await _unitOfWork.SaveChangesAsync(default);

            return _mapper.Map<BuildingResponse>(building);
        }

        public async Task DeleteBuildingAsync(Guid id, CancellationToken cancellationToken)
        {
            var building = await _unitOfWork.BuildingRepository.GetBuildingByIdAsync(new BuildingId(id));

            if (building is  null)
                throw new Exception("Building not found");


            await _unitOfWork.BuildingRepository.DeleteBuildingAsync(building);


            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<BuildingResponse?> GetBuildingByIdAsync(Guid id)
        {
            var building = await _buildingQueries.GetBuildingByIdAsync(id);

            if (building is null)
                throw new Exception("Building not found");

            return _mapper.Map<BuildingResponse>(building);
        }

        public async Task<List<BuildingResponse>> GetBuildingsAsync()
        {
            var buildings = await _buildingQueries.GetBuildingsAsync();

            if (buildings.Count == 0)
                return [];

            return _mapper.Map<List<BuildingResponse>>(buildings);
        }

        public async Task UpdateBuildingAsync(Guid id, string buildingName, string street, string city, string state, string zip, int numberOfFloors, int yearBuilt, string? notes)
        {
            var building = await _unitOfWork.BuildingRepository.GetBuildingByIdAsync(new BuildingId(id));

            if(building is null)
                throw new Exception("Building not found");

            string updatedStreet = street == "" ? building.BuildingAddress.Street : street;
            string updatedCity = city == "" ? building.BuildingAddress.City : city;
            string updatedState = state == "" ? building.BuildingAddress.Street : state;
            string updatedZipcode = zip == "" ? building.BuildingAddress.ZipCode : zip;

            building.Update(buildingName, new Address(updatedStreet, updatedCity, updatedState, updatedZipcode), numberOfFloors, yearBuilt, notes: notes);

            await _unitOfWork.BuildingRepository.UpdateBuildingAsync(building);

            await _unitOfWork.SaveChangesAsync(default);
        }
    }
}
