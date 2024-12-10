using AutoMapper;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Contractors;

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

        CreateMap<ContractorProfileDto, CreateUpdateContractorProfileDto>();

        CreateMap<ContractorLocationDto, CreateUpdateContractorLocationDto>();

        CreateMap<ContractorPortfolioItemDto, CreateUpdateContractorPortfolioItemDto>()
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());
    }
}
