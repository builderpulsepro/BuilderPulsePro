using AutoMapper;
using BuilderPulsePro.Builders;

namespace BuilderPulsePro.Blazor;

public class BuilderPulseProBlazorAutoMapperProfile : Profile
{
    public BuilderPulseProBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.
        CreateMap<BuilderProfileDto, CreateUpdateBuilderProfileDto>();

        CreateMap<BuilderLocationDto, CreateUpdateBuilderLocationDto>();

        CreateMap<BuilderPortfolioItemDto, CreateUpdateBuilderPortfolioItemDto>()
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());
    }
}
