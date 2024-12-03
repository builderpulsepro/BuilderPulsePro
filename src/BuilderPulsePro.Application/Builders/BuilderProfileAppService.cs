using System;
using System.Threading.Tasks;
using BuilderPulsePro.Blobs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

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
        private readonly IBlobContainer<BuilderPortfolioContainer> _blobContainer;
        private readonly IGuidGenerator _guidGenerator;

        public BuilderProfileAppService(IRepository<BuilderProfile, Guid> repository, 
            IBlobContainer<BuilderPortfolioContainer> blobContainer,
            IGuidGenerator guidGenerator) : base(repository)
        {
            _blobContainer = blobContainer;
            _guidGenerator = guidGenerator;
        }

        public async Task<BuilderProfileDto> GetCurrentUserBuilderProfileAsync()
        {
            var profile = await Repository.FirstOrDefaultAsync(x => x.CreatorId == CurrentUser.Id);

            return ObjectMapper.Map<BuilderProfile, BuilderProfileDto>(profile!);
        }

        public async Task<string> SavePortfolioItemAsync(byte[] bytes)
        {
            var blobName = _guidGenerator.Create().ToString();
            await _blobContainer.SaveAsync(blobName, bytes);
            return blobName;
        }

        public async Task<byte[]> GetPortfolioPictureAsync(string blobName)
        {
            return await _blobContainer.GetAllBytesOrNullAsync(blobName);
        }

        public async Task DeletePortfolioItemAsync(string blobName)
        {
            await _blobContainer.DeleteAsync(blobName);
        }
    }
}
