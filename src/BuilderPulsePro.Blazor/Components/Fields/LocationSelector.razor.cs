using Blazorise;
using BuilderPulsePro.Locations;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NetTopologySuite.Geometries;
using System.Threading.Tasks;

namespace BuilderPulsePro.Blazor.Components.Fields
{
    public partial class LocationSelector
    {
        [Parameter]
        public CreateUpdateLocationDto Location { get; set; } = new CreateUpdateLocationDto();

        [Parameter] 
        public EventCallback<CreateUpdateLocationDto> OnLocationSelected { get; set; }

        private bool HasAddress => Location != null && !string.IsNullOrEmpty(Location.Street1);

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await jsRuntime.InvokeVoidAsync("initializeAutocomplete", "autocomplete", DotNetObjectReference.Create(this));
            }
        }

        [JSInvokable]
        public async Task OnPlaceSelected(double lat, double lng, CreateUpdateLocationDto address)
        {
            if (Location == null) 
            {
                Location = new CreateUpdateLocationDto();
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

            //Address = address;
            if (OnLocationSelected.HasDelegate)
            {
                await OnLocationSelected.InvokeAsync(Location);
            }

            await InvokeAsync(StateHasChanged);
        }
    }
}
