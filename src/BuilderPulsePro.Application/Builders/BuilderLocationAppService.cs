using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BuilderPulsePro.Builders
{
    public class BuilderLocationAppService :
       CrudAppService<
           BuilderLocation,
           BuilderLocationDto,
           Guid,
           PagedAndSortedResultRequestDto,
           CreateUpdateBuilderLocationDto>, IBuilderLocationAppService
    {
        public BuilderLocationAppService(IRepository<BuilderLocation, Guid> repository) : base(repository)
        {
        }
    }
}
