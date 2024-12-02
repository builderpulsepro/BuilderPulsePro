using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BuilderPulsePro.Builders
{
    public interface IBuilderLocationAppService :
        ICrudAppService<
            BuilderLocationDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBuilderLocationDto>
    {
    }
}
