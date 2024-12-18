using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BuilderPulsePro.Projects
{
    public interface IProjectAppService :
        ICrudAppService<
            ProjectDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProjectDto>
    {
        Task<PagedResultDto<ProjectDto>> GetProjectsByBuilderAsync(ProjectListFilterDto input);
        Task<PagedResultDto<ProjectDto>> GetProjectsByContractorAsync(ProjectListFilterDto input);
    }
}
