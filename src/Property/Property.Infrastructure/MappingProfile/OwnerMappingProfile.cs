using AutoMapper;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Infrastructure.MappingProfile
{
    public class OwnerMappingProfile : Profile
    {
        public OwnerMappingProfile() 
        {
            CreateMap<Owner, OwnerReponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FullName.FirstName} {src.FullName.LastName}"));
        }
    }
}
