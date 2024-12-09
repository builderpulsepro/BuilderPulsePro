using System.Collections.Generic;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.DataGrid;
using BuilderPulsePro.Builders;
using Microsoft.AspNetCore.Components;

namespace BuilderPulsePro.Blazor.Builders.Fields
{
    public partial class LocationMultiSelect
    {
        [Parameter]
        public ICollection<CreateUpdateBuilderLocationDto> Locations { get; set; }

        public CreateUpdateBuilderLocationDto CurrentLocation { get; set; }

        private Modal LocationModal { get; set; }

        private DataGrid<CreateUpdateBuilderLocationDto> gridRef { get; set; }

        private Validations Validator;

        private async Task ShowLocationModal(CreateUpdateBuilderLocationDto? current)
        {
            CurrentLocation = current;
            await LocationModal.Show();
        }

        private async Task CloseLocationModal()
        {
            await LocationModal.Hide();
        }

        private async Task SaveLocation()
        {
            if (await Validator.ValidateAll() == false)
            {
                return;
            }

            if (!CurrentLocation.Id.HasValue)
            {
                CurrentLocation.Id = GuidGenerator.Create();
                Locations.Add(CurrentLocation);
            }

            await LocationModal.Hide();

            await gridRef.Reload();

            await InvokeAsync(StateHasChanged);
        }

        private async Task HandleLocationSelected(CreateUpdateBuilderLocationDto location)
        {
            CurrentLocation.Street1 = location.Street1;
            CurrentLocation.Street2 = location.Street2;
            CurrentLocation.City = location.City;
            CurrentLocation.State = location.State;
            CurrentLocation.ZipCode = location.ZipCode;
            CurrentLocation.Country = location.Country;
            CurrentLocation.Latitude = location.Latitude;
            CurrentLocation.Longitude = location.Longitude;
            await Task.CompletedTask;
        }

        private void ValidateLocation(ValidatorEventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentLocation.Name) || 
                string.IsNullOrEmpty(CurrentLocation.Country))
            {
                e.Status = ValidationStatus.Error;
                e.ErrorText = string.IsNullOrEmpty(CurrentLocation.Name) ? 
                    L["LocationMultiSelect:Error:NameRequired"] :
                    L["LocationMultiSelect:Error:AddressRequired"];
            }
            else
            {
                e.Status = ValidationStatus.Success;
            }
        }

        private async Task DeleteLocation(CreateUpdateBuilderLocationDto location)
        {
            Locations.Remove(location);

            await gridRef.Reload();

            await InvokeAsync(StateHasChanged);
        }
    }
}
