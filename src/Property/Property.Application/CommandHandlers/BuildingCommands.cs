using AutoMapper;
using Property.Application.Commnds;
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

        public BuildingCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BuildingResponse> AddBuildingAsync(string buildingName, string buildingNumber, string street, string city, string state, string zip, int numberOfFloors, int yearBuilt)
        {
            var building = Building.Create(buildingName, buildingNumber, new BuildingAddress(street, city, state, zip), numberOfFloors, yearBuilt);

            await _unitOfWork.BuildingRepository.AddBuildingAsync(building);
            await _unitOfWork.SaveChangesAsync(default);

            return _mapper.Map<BuildingResponse>(building);
        }

        public async Task DeleteBuildingAsync(Guid id, CancellationToken cancellationToken)
        {
            var building = await _unitOfWork.BuildingRepository.GetBuildingByIdAsync(new BuildingId(id));

            if (building is not null)
                await _unitOfWork.BuildingRepository.DeleteBuildingAsync(building);


            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<Building?> UpdateBuildingAsync(Guid id, string buildingName, string street, string city, string state, string zip, int numberOfFloors, int yearBuilt, string? notes)
        {
            var building = await _unitOfWork.BuildingRepository.GetBuildingByIdAsync(new BuildingId(id));

            if(building != null){

                building.Update(buildingName, new BuildingAddress(street, city, state, zip), numberOfFloors, yearBuilt, notes: notes);

                return building;
            }

            return null;
        }
    }
}
