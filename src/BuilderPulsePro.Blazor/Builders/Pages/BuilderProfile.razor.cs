using System;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using BuilderPulsePro.Builders;
using Microsoft.AspNetCore.Components;

namespace BuilderPulsePro.Blazor.Builders.Pages
{
    public partial class BuilderProfile
    {
        [Parameter]
        public Guid? Id { get; set; }

        [Parameter]
        public bool IsReadOnly { get; set; }

        private CreateUpdateBuilderProfileDto Profile { get; set; } = new CreateUpdateBuilderProfileDto();

        private Validations Validator;

        private string selectedTab = "General";

        protected override async Task OnParametersSetAsync()
        {
            if (Id.HasValue)
            {
                var profile = await builderAppService.GetAsync(Id.Value);
                Profile = ObjectMapper.Map<BuilderProfileDto, CreateUpdateBuilderProfileDto>(profile);
            }
            else
            {
                Profile = new CreateUpdateBuilderProfileDto();
            }

            await base.OnParametersSetAsync();
        }

        private async Task Save()
        {
            var isValid = await Validator.ValidateAll();
            if (isValid)
            {
                foreach (var item in Profile.PortfolioItems.Where(x => x.IsDeleted))
                {
                    // removed portfolio item, cleanup blob storage
                    await builderAppService.DeletePortfolioItemAsync(item.BlobName);
                }

                Profile.PortfolioItems = Profile.PortfolioItems.Where(x => !x.IsDeleted).ToList();

                if (!Id.HasValue)
                {
                    await builderAppService.CreateAsync(Profile);
                }
                else
                {
                    await builderAppService.UpdateAsync(Id.Value, Profile);
                }
                Nav.NavigateTo("/BuilderDashboard", true);
            }
        }

        private async Task Cancel()
        {
            foreach (var item in Profile.PortfolioItems.Where(x => !x.Id.HasValue))
            {
                // new unsaved portfolio item, cleanup blob storage
                await builderAppService.DeletePortfolioItemAsync(item.BlobName);
            }

            Nav.NavigateTo("/BuilderDashboard", true);
        }

        private async Task OnSelectedTabChanged(string name)
        {
            selectedTab = name;

            await Task.CompletedTask;
        }
    }
}
