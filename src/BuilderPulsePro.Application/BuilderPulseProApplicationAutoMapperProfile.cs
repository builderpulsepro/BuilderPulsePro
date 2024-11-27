using AutoMapper;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Locations;
using NetTopologySuite.Geometries;
using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace BuilderPulsePro;

public class BuilderPulseProApplicationAutoMapperProfile : Profile
{
    public BuilderPulseProApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<BuilderProfile, BuilderProfileDto>();
        CreateMap<CreateUpdateBuilderProfileDto, BuilderProfile>();

        CreateMap<Locations.Location, LocationDto>()
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Coordinates.Y))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Coordinates.X));
        CreateMap<CreateUpdateLocationDto, Locations.Location>()
            .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => new Point(src.Longitude, src.Latitude, 0) { SRID = 4326 }));
    }
}
