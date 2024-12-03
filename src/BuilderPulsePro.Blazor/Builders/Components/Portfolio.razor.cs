using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Blazorise;
using BuilderPulsePro.Builders;
using Microsoft.AspNetCore.Components;

namespace BuilderPulsePro.Blazor.Builders.Components
{
    public partial class Portfolio
    {
        [Parameter]
        public ICollection<CreateUpdateBuilderPortfolioItemDto> PortfolioItems { get; set; }

        private async Task OnFileEditChanged(FileChangedEventArgs e)
        {
            foreach (var item in e.Files)
            {
                using (var stream = new MemoryStream())
                {
                    await item.WriteToStreamAsync(stream);

                    stream.Seek(0, SeekOrigin.Begin);

                    var bytes = await stream.GetAllBytesAsync();

                    var savedBlobName = await builderAppService.SavePortfolioItemAsync(bytes);

                    PortfolioItems.Add(new CreateUpdateBuilderPortfolioItemDto
                    {
                        BlobName = savedBlobName,
                        Description = "Test"
                    });
                }
            }

            await Task.CompletedTask;
        }

        private async Task DeletePortfolioItem(CreateUpdateBuilderPortfolioItemDto item)
        {
            item.IsDeleted = true;
            await Task.CompletedTask;
        }

    }
}
