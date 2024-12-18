using System;
using System.Threading.Tasks;
using BuilderPulsePro.Blobs;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Contractors;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Account.Public.Web.Impersonation;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.BlobStoring;

namespace BuilderPulsePro.Blazor.Controllers;

[Route("api/contractor-portfolio-images")]
public class ContractorProfileBlobContainerController : AbpController
{
    private readonly IContractorProfileAppService _builderAppService;

    public ContractorProfileBlobContainerController(IContractorProfileAppService builderAppService)
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
