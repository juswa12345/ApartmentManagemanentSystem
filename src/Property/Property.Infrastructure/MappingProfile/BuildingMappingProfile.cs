using AutoMapper;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Infrastructure.MappingProfile
{
    public class BuildingMappingProfile : Profile
    {
        public BuildingMappingProfile(){

            CreateMap<Building, BuildingResponse>()
                .ForMember(dest => dest.BuildingAddress, opt => opt.MapFrom(src => $"{src.BuildingAddress.Street} {src.BuildingAddress.City}, {src.BuildingAddress.State}"))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));


            CreateMap<Unit, UnitsResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.UnitNumber, opt => opt.MapFrom(src => src.UnitNumber))
                .ForMember(dest => dest.FloorNumber, opts => opts.MapFrom(src => src.Floor))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status));

            CreateMap<Unit, UnitResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));

        }
    }
}
