using System.Threading.Tasks;
using BuilderPulsePro.Builders;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BuilderPulsePro.Blazor.Builders.Fields
{
    public partial class LocationSelector
    {
        [Parameter]
        public CreateUpdateBuilderLocationDto Location { get; set; } = new CreateUpdateBuilderLocationDto();

        [Parameter] 
        public EventCallback<CreateUpdateBuilderLocationDto> OnLocationSelected { get; set; }

        [Parameter]
        public bool ShowExtraFields { get; set; }

        private bool HasAddress => Location != null && !string.IsNullOrEmpty(Location.Country);

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await jsRuntime.InvokeVoidAsync("initializeAutocomplete", "autocomplete", DotNetObjectReference.Create(this));
            }
        }

        [JSInvokable]
        public async Task OnPlaceSelected(double lat, double lng, CreateUpdateBuilderLocationDto address)
        {
            if (Location == null) 
            {
                Location = new CreateUpdateBuilderLocationDto();
            }
            if (address == null)
            {
                return;
            }
            
            Location.Street1 = address.Street1;
            Location.Street2 = address.Street2;
            Location.City = address.City;
            Location.State = address.State;
            Location.ZipCode = address.ZipCode;
            Location.Country = address.Country;
            Location.Latitude = lat;
            Location.Longitude = lng;

            if (OnLocationSelected.HasDelegate)
            {
                await OnLocationSelected.InvokeAsync(Location);
            }

            await InvokeAsync(StateHasChanged);
        }
    }
}
