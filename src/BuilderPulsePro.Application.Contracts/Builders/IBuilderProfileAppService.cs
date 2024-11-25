using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BuilderPulsePro.Builders
{
    public interface IBuilderProfileAppService :
        ICrudAppService<
            BuilderProfileDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBuilderProfileDto>
    {
        Task<BuilderProfileDto> GetCurrentUserBuilderProfileAsync();
    }
}
