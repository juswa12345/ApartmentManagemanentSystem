using AutoMapper;
using Identity.Application.Response;
using Identity.Domain.Entities;

namespace Identity.Infrastructure.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));
        }
    }
}
