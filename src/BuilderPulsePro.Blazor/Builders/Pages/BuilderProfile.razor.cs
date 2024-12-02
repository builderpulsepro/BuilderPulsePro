﻿using System;
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
            Nav.NavigateTo("/BuilderDashboard", true);
            await Task.CompletedTask;
        }

        private async Task OnSelectedTabChanged(string name)
        {
            selectedTab = name;

            await Task.CompletedTask;
        }
    }
}