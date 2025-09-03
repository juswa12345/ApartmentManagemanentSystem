using AutoMapper;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Infrastructure.MappingProfile
{
    public class BuildingMappingProfile : Profile
    {
        public BuildingMappingProfile(){

            CreateMap<Unit, UnitResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));

            CreateMap<Tenant, TenantReponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.TenantName.FirstName} {src.TenantName.LastName}"))
                .ForMember(dest => dest.Contracts, opt => opt.MapFrom(src => src.LeaseRecords));


            CreateMap<LeasingRecord, LeaseResponse>()
                .ForMember(dest => dest.unitId, opt => opt.MapFrom(src => src.UnitId.Value))
                .ForMember(dest => dest.UnitNumber, opt => opt.MapFrom(src => src.Unit.UnitNumber))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Term.Start))
                .ForMember(dest => dest.unitId, opt => opt.MapFrom(src => src.Term.End));

        }
    }
}
