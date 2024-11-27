using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace BuilderPulsePro.Builders
{
    public class BuilderProfileAppService :
        CrudAppService<
            BuilderProfile,
            BuilderProfileDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBuilderProfileDto>, IBuilderProfileAppService
    {
        public BuilderProfileAppService(IRepository<BuilderProfile, Guid> repository) : base(repository)
        {

        }

        public async Task<BuilderProfileDto> GetCurrentUserBuilderProfileAsync()
        {
            var profile = await Repository.FirstOrDefaultAsync(x => x.CreatorId == CurrentUser.Id);

            return ObjectMapper.Map<BuilderProfile, BuilderProfileDto>(profile!);
        }

        public override async Task<BuilderProfileDto> CreateAsync(CreateUpdateBuilderProfileDto input)
        {
            // Map DTO to entity
            var builderProfile = ObjectMapper.Map<CreateUpdateBuilderProfileDto, BuilderProfile>(input);

            var result = await Repository.InsertAsync(builderProfile);

            // Return mapped result
            return ObjectMapper.Map<BuilderProfile, BuilderProfileDto>(result);
        }
    }
}
