using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPulsePro.Blobs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using System.Linq.Dynamic.Core;
using Volo.Abp;

namespace BuilderPulsePro.Projects
{
    public class ProjectAppService : CrudAppService<
            Project,
            ProjectDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProjectDto>, IProjectAppService
    {
        private readonly IRepository<Project, Guid> _projectRepository;

        public ProjectAppService(IRepository<Project, Guid> repository) : base(repository)
        {
            _projectRepository = repository;
        }

        public async Task<PagedResultDto<ProjectDto>> GetProjectsByBuilderAsync(ProjectListFilterDto input)
        {
            if (!input.BuilderId.HasValue)
            {
                throw new BusinessException("BuilderId is missing.");
            }

            var queryable = await _projectRepository.GetQueryableAsync();

            // Apply filter
            var filteredQuery = queryable
                .Where(x => x.BuilderProfileID == input.BuilderId.Value)
                .OrderBy(input.Sorting ?? nameof(Project.Title))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var totalCount = await AsyncExecuter.CountAsync(queryable);
            var projects = await AsyncExecuter.ToListAsync(filteredQuery);

            return new PagedResultDto<ProjectDto>(
                totalCount,
                ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects)
            );
        }

        public async Task<PagedResultDto<ProjectDto>> GetProjectsByContractorAsync(ProjectListFilterDto input)
        {
            if (!input.ContractorId.HasValue)
            {
                throw new BusinessException("ContractorId is missing.");
            }

            var queryable = await _projectRepository.GetQueryableAsync();

            // Apply filter
            var filteredQuery = queryable
                .Where(p => p.ProjectTasks.Any(t => t.ContractorProfileId == input.ContractorId.Value))
                .OrderBy(input.Sorting ?? nameof(Project.Title))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var totalCount = await AsyncExecuter.CountAsync(queryable);
            var projects = await AsyncExecuter.ToListAsync(filteredQuery);

            return new PagedResultDto<ProjectDto>(
                totalCount,
                ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects)
            );
        }
    }
}
