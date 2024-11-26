using AutoMapper;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Locations;
using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace BuilderPulsePro;

public class BuilderPulseProApplicationAutoMapperProfile : Profile
{
    public BuilderPulseProApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<BuilderProfile, BuilderProfileDto>()
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
            .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId));
        CreateMap<CreateUpdateBuilderProfileDto, BuilderProfile>();

        CreateMap<Location, LocationDto>();
    }
}
