using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BuilderPulsePro.Locations
{
    public interface ILocationAppService :
        ICrudAppService<
            LocationDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLocationDto>
    {
    }
}
