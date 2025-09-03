using AutoMapper;
using Property.Application.Commnds;
using Property.Application.Repositories;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.Services;
using Property.Domain.ValueObjects;

namespace Property.Application.CommandHandlers
{
    public class PropertyOwnershipCommands : IPropertyOwnershipCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyOwnershipCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateOwnership(Guid ownerId, Guid unitId)
        {
            var unit = await _unitOfWork.UnitReposirtory.GetUnitByIdAsync(new UnitId(unitId));

            if(unit is null)
                throw new Exception("Unit not found");

            var owner = await _unitOfWork.OwnerRepository.GetOwnerByIdAsync(new OwnerId(ownerId));

            if(owner is null) throw new Exception("Owner not found");

            var ownershipServices = new OwnershipServices();

            PropertyOwnership propertyOwnership = ownershipServices.AddOwnership(owner, unit);

            await _unitOfWork.OwnershipRepository.AddOwnershipAsync(propertyOwnership);
            await _unitOfWork.SaveChangesAsync(default);
        }

        public async Task<List<OwnershipResponse>> GetOwnershipsAsync()
        {
            var ownerships = await _unitOfWork.OwnershipRepository.GetPropertyOwnershipsAsync();

            if (ownerships.Count == 0)
                return [];

            return _mapper.Map<List<OwnershipResponse>>(ownerships);
        }
    }
}
