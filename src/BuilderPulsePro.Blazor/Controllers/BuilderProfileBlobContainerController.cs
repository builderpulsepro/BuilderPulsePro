using System;
using System.Threading.Tasks;
using BuilderPulsePro.Blobs;
using BuilderPulsePro.Builders;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Account.Public.Web.Impersonation;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.BlobStoring;

namespace BuilderPulsePro.Blazor.Controllers;

[Route("api/portfolio-images")]
public class BuilderProfileBlobContainerController : AbpController
{
    private readonly IBuilderProfileAppService _builderAppService;

    public BuilderProfileBlobContainerController(IBuilderProfileAppService builderAppService)
    {
        _builderAppService = builderAppService;
    }

    [HttpGet("{blobName}")]
    public async Task<IActionResult> GetImageAsync(string blobName)
    {
        try
        {
            var imageBytes = await _builderAppService.GetPortfolioPictureAsync(blobName);

            return File(imageBytes, "image/png");
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }
}
