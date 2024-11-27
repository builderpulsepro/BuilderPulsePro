using Blazorise;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Locations;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Volo.Abp.Validation;

namespace BuilderPulsePro.Blazor.Components
{
    public partial class BuilderProfile
    {
        [Parameter]
        public Guid? Id { get; set; }

        [Parameter]
        public bool IsReadOnly { get; set; }

        private CreateUpdateBuilderProfileDto Profile { get; set; } = new CreateUpdateBuilderProfileDto();
        private CreateUpdateLocationDto Location { get; set; } = new CreateUpdateLocationDto();
        private Validations Validator;

        private string selectedTab = "General";

        protected override async Task OnParametersSetAsync()
        {
            if (Id.HasValue)
            {
                var profile = await builderAppService.GetAsync(Id.Value);
                Profile = ObjectMapper.Map<BuilderProfileDto, CreateUpdateBuilderProfileDto>(profile);
                if (Profile.LocationId.HasValue && Profile.LocationId.Value != Guid.Empty)
                {
                    var location = await locationAppService.GetAsync(Profile.LocationId.Value);
                    Location = ObjectMapper.Map<LocationDto, CreateUpdateLocationDto>(location);
                }
                else
                {
                    Location = new CreateUpdateLocationDto();
                }
            }
            else
            {
                Profile = new CreateUpdateBuilderProfileDto();
                Location = new CreateUpdateLocationDto();
            }

            await base.OnParametersSetAsync();
        }

        private async Task Save()
        {
            var isValid = await Validator.ValidateAll();
            if (isValid) 
            { 
                if (!Id.HasValue)
                {
                    if (Location != null && !string.IsNullOrEmpty(Location.Street1))
                    {
                        var location = await locationAppService.CreateAsync(Location);
                        Profile.LocationId = location.Id.Value;
                    }

                    await builderAppService.CreateAsync(Profile);
                }
                else
                {
                    if (Location != null && !string.IsNullOrEmpty(Location.Street1))
                    {
                        if (Location.Id.HasValue)
                        {
                            var location = await locationAppService.UpdateAsync(Location.Id.Value, Location);
                            Profile.LocationId = location.Id.Value;
                        }
                        else
                        {
                            var location = await locationAppService.CreateAsync(Location);
                            Profile.LocationId = location.Id.Value;
                        }
                    }


                    await builderAppService.UpdateAsync(Id.Value, Profile);
                }
                Nav.NavigateTo("/BuilderDashboard", true);
            }
        }

        private async Task Cancel()
        {
            Nav.NavigateTo("/BuilderDashboard", true);
            await Task.CompletedTask;
        }

        private async Task OnSelectedTabChanged(string name)
        {
            selectedTab = name;

            await Task.CompletedTask;
        }

        private async Task HandleLocationSelected(CreateUpdateLocationDto location)
        {
            if (Location == null)
            {
                Location = location;
            }
            else
            {
                Location.Street1 = location.Street1;
                Location.Street2 = location.Street2;
                Location.City = location.City;
                Location.State = location.State;
                Location.ZipCode = location.ZipCode;
                Location.Country = location.Country;
                Location.Longitude = location.Longitude;
                Location.Latitude = location.Latitude;
            }

            await InvokeAsync(StateHasChanged);
        }
    }
}
