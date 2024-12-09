let autocomplete;
function initializeAutocomplete(element, dotNetHelper) {
    const input = document.getElementById(element);
    autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.addListener('place_changed', () => {
        const place = autocomplete.getPlace();
        const lat = place.geometry.location.lat();
        const lng = place.geometry.location.lng();
        dotNetHelper.invokeMethodAsync('OnPlaceSelected', lat, lng, parseAddressComponents(place.address_components));
        input.value = '';
        autocomplete.setBounds(null);
    });
}

function parseAddressComponents(addressComponents) {
    const parsedAddress = {
        Street1: '',
        Street2: '',
        City: '',
        //County: '',
        State: '',
        ZipCode: '',
        Country: '',
    };

    addressComponents.forEach(component => {
        const types = component.types;

        if (types.includes('street_number') && component.long_name) {
            parsedAddress.Street1 = component.long_name + ' ' + (parsedAddress.Street1 || '');
        }

        if (types.includes('route') && component.long_name) {
            parsedAddress.Street1 = (parsedAddress.Street1 || '') + component.long_name;
        }

        if (types.includes('subpremise')) {
            parsedAddress.Street2 = component.long_name;
        }

        if (types.includes('locality')) {
            parsedAddress.City = component.long_name;
        }

        //if (types.includes('administrative_area_level_2')) {
        //    parsedAddress.County = component.long_name;
        //}

        if (types.includes('administrative_area_level_1')) {
            parsedAddress.State = component.short_name; // Use short_name for "WA"
        }

        if (types.includes('postal_code')) {
            parsedAddress.ZipCode = component.long_name;
        }

        if (types.includes('country')) {
            parsedAddress.Country = component.long_name;
        }
    });

    return parsedAddress;
}