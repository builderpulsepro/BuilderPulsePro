using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BuilderPulsePro.Projects
{
    public class ProjectListFilterDto : PagedAndSortedResultRequestDto
    {
        public Guid? BuilderId { get; set; }
        public Guid? ContractorId { get; set; }
    }
}
