using AutoMapper;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Contractors;
using BuilderPulsePro.Projects;

namespace BuilderPulsePro.Blazor;

public class BuilderPulseProBlazorAutoMapperProfile : Profile
{
    public BuilderPulseProBlazorAutoMapperProfile()
    {
        // TODO : New Entity

        // BUILDER
        CreateMap<BuilderProfileDto, CreateUpdateBuilderProfileDto>();

        CreateMap<BuilderLocationDto, CreateUpdateBuilderLocationDto>();

        CreateMap<BuilderPortfolioItemDto, CreateUpdateBuilderPortfolioItemDto>()
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

        // CONTRACTOR
        CreateMap<ContractorProfileDto, CreateUpdateContractorProfileDto>();

        CreateMap<ContractorLocationDto, CreateUpdateContractorLocationDto>();

        CreateMap<ContractorPortfolioItemDto, CreateUpdateContractorPortfolioItemDto>()
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

        // PROJECT
        CreateMap<ProjectDto, CreateUpdateProjectDto>();

        CreateMap<ProjectTaskDto, CreateUpdateProjectTaskDto>();

        CreateMap<ProjectTaskDependencyDto, CreateUpdateProjectTaskDependencyDto>();

    }
}
