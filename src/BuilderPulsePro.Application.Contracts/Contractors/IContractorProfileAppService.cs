using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BuilderPulsePro.Contractors
{
    public interface IContractorProfileAppService :
        ICrudAppService<
            ContractorProfileDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateContractorProfileDto>
    {
        Task<ContractorProfileDto> GetCurrentUserContractorProfileAsync();
        Task<string> SavePortfolioItemAsync(byte[] bytes);
        Task<byte[]> GetPortfolioPictureAsync(string blobName);
        Task DeletePortfolioItemAsync(string blobName);
    }
}
