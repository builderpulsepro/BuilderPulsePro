using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

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

        //public override async Task<BuilderProfileDto> UpdateAsync(Guid id, CreateUpdateBuilderProfileDto dto)
        //{
        //    var profile = await base.UpdateAsync(id, dto);

        //    var existingLocations = await _locationRepository.GetListAsync(x => x.BuilderProfileId == id);

        //    foreach (var locationDto in dto.Locations)
        //    {
        //        if (locationDto.Id == null)
        //        {
        //            locationDto.Id = GuidGenerator.Create();

        //            var location = ObjectMapper.Map<CreateUpdateBuilderLocationDto, BuilderLocation>(locationDto);
        //            location.BuilderProfileId = id;

        //            await _locationRepository.InsertAsync(location);
        //        }
        //        else
        //        {
        //            var location = ObjectMapper.Map<CreateUpdateBuilderLocationDto, BuilderLocation>(locationDto);
        //            location.BuilderProfileId = id;

        //            await _locationRepository.UpdateAsync(location);
        //        }
        //    }

        //    //foreach (var existingLocation in existingLocations)
        //    //{
        //    //    if (dto.Locations.FirstOrDefault(x => x.Id == existingLocation.Id) == null)
        //    //    {
        //    //        await _locationRepository.DeleteAsync(existingLocation);
        //    //    }
        //    //}

        //    var result = await GetAsync(id);

        //    return result;
        //}
    }
}
