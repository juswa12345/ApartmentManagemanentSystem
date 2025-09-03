using AutoMapper;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Infrastructure.MappingProfile
{
    public class OwnershipMappingProfile : Profile
    {
        public OwnershipMappingProfile() 
        {

            CreateMap<PropertyOwnership, OwnershipResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.OwnedDate, opt => opt.MapFrom(src => src.DateOwned));


            CreateMap<Unit, UnitOwnershipResponse>()
                .ForMember(dest => dest.UnitId, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.UnitNumber, opt => opt.MapFrom(src => src.UnitNumber));

            CreateMap<Owner, OwnerDetailsResponse>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FullName.FirstName} {src.FullName.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactNumber));

        }
    }
}
