using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using BuilderPulsePro.Contractors;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;

namespace BuilderPulsePro.Blazor.Contractors.Components
{
    public partial class Portfolio
    {
        [Parameter]
        public ICollection<CreateUpdateContractorPortfolioItemDto> PortfolioItems { get; set; }

        private async Task OnFileEditChanged(FileChangedEventArgs e)
        {
            foreach (var item in e.Files)
            {
                using (var stream = new MemoryStream())
                {
                    await item.WriteToStreamAsync(stream);

                    stream.Seek(0, SeekOrigin.Begin);

                    var bytes = await stream.GetAllBytesAsync();

                    var savedBlobName = await contractorAppService.SavePortfolioItemAsync(bytes);

                    PortfolioItems.Add(new CreateUpdateContractorPortfolioItemDto
                    {
                        Id = GuidGenerator.Create(),
                        BlobName = savedBlobName,
                        Description = "Test"
                    });
                }
            }

            await Task.CompletedTask;
        }

        private async Task DeletePortfolioItem(CreateUpdateContractorPortfolioItemDto item)
        {
            item.IsDeleted = true;
            await Task.CompletedTask;
        }

        private IEnumerable<CreateUpdateContractorPortfolioItemDto> AllItems => PortfolioItems == null ? [] : PortfolioItems.Where(x => !x.IsDeleted);

        private List<CreateUpdateContractorPortfolioItemDto> VisibleIndicators = new();

        private void UpdateVisibleIndicators()
        {
            VisibleIndicators.Clear();
            int totalItems = AllItems.Count();

            if (totalItems <= 5)
            {
                // Show all items if there are fewer than 5
                VisibleIndicators.AddRange(AllItems);
            }
            else
            {
                for (int i = -2; i <= 2; i++) // Show 2 items before and after the current index
                {
                    int wrappedIndex = (_selectedIndex + i + totalItems) % totalItems; // Handle circular indices
                    VisibleIndicators.Add(AllItems.ToArray()[wrappedIndex]);
                }
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            // Initialize the carousel with the selected index, e.g., 0
            UpdateVisibleIndicators();
        }

        private void OnSelectedIndexChanged(int selectedIndex)
        {
            _selectedIndex = selectedIndex;
            UpdateVisibleIndicators();
        }

        private bool IsIndexInVisibleIndicators(int index)
        {
            int totalItems = AllItems.Count();

            if (totalItems == 0)
            {
                return false;
            }

            // Calculate the valid indices for visible items
            for (int i = -2; i <= 2; i++)
            {
                int wrappedIndex = (_selectedIndex + i + totalItems) % totalItems;
                if (wrappedIndex == index) return true;
            }

            return false;
        }

        private string GetVisibleBlobName(int index)
        {
            int totalItems = AllItems.Count();

            for (int i = -2; i <= 2; i++)
            {
                int wrappedIndex = (_selectedIndex + i + totalItems) % totalItems;
                if (wrappedIndex == index) return AllItems.ToArray()[wrappedIndex].BlobName;
            }

            return string.Empty; // Fallback (shouldn't happen if logic is correct)
        }

        private int _selectedIndex = 0;
    }
}
