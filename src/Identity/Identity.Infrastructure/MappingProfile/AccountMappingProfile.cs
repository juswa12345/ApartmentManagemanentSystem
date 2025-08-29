using AutoMapper;
using Identity.Application.Response;
using Identity.Domain.Entities;

namespace Identity.Infrastructure.MappingProfile
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile() 
        {
            CreateMap<Account, AccountResponse>()
               .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id.Value))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.Address.Street} {src.Address.City} {src.Address.State}"))
               .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.User.Roles))
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FullName.FirstName} {src.FullName.LastName}"));
        }
    }
}
