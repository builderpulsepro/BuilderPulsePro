using AutoMapper;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Locations;

namespace BuilderPulsePro.Blazor;

public class BuilderPulseProBlazorAutoMapperProfile : Profile
{
    public BuilderPulseProBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.
        CreateMap<BuilderProfileDto, CreateUpdateBuilderProfileDto>();

        CreateMap<LocationDto, CreateUpdateLocationDto>();
    }
}
