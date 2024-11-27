using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BuilderPulsePro.Locations
{
    public class LocationAppService :
        CrudAppService<
            Location,
            LocationDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLocationDto>, ILocationAppService
    {
        public LocationAppService(IRepository<Location, Guid> repository) : base(repository)
        {

        }
    }
}
