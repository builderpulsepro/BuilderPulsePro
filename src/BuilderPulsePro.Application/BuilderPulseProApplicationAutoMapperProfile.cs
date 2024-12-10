using AutoMapper;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Contractors;
using BuilderPulsePro.Projects;
using NetTopologySuite.Geometries;

namespace BuilderPulsePro;

public class BuilderPulseProApplicationAutoMapperProfile : Profile
{
    public BuilderPulseProApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        // TODO : New Entity

        // BUILDERS
        CreateMap<BuilderProfile, BuilderProfileDto>();
        CreateMap<CreateUpdateBuilderProfileDto, BuilderProfile>();

        CreateMap<BuilderLocation, BuilderLocationDto>()
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Coordinates.Y))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Coordinates.X));
        CreateMap<CreateUpdateBuilderLocationDto, BuilderLocation>()
            .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => new Point(src.Longitude, src.Latitude, 0) { SRID = 4326 }));

        CreateMap<BuilderPortfolioItem, BuilderPortfolioItemDto>();
        CreateMap<CreateUpdateBuilderPortfolioItemDto, BuilderPortfolioItem>();

        // CONTRACTORS
        CreateMap<ContractorProfile, ContractorProfileDto>();
        CreateMap<CreateUpdateContractorProfileDto, ContractorProfile>();

        CreateMap<ContractorLocation, ContractorLocationDto>()
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Coordinates.Y))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Coordinates.X));
        CreateMap<CreateUpdateContractorLocationDto, ContractorLocation>()
            .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => new Point(src.Longitude, src.Latitude, 0) { SRID = 4326 }));

        CreateMap<ContractorPortfolioItem, ContractorPortfolioItemDto>();
        CreateMap<CreateUpdateContractorPortfolioItemDto, ContractorPortfolioItem>();

        // PROJECTS
        CreateMap<Project, ProjectDto>();
        CreateMap<CreateUpdateProjectDto, Project>();

        CreateMap<ProjectTask, ProjectTaskDto>();
        CreateMap<CreateUpdateProjectTaskDto, ProjectTask>();
    }
}
