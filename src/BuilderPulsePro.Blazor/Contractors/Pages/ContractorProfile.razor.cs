﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using BuilderPulsePro.Contractors;
using BuilderPulsePro.Enums;
using Microsoft.AspNetCore.Components;

namespace BuilderPulsePro.Blazor.Contractors.Pages
{
    public partial class ContractorProfile
    {
        [Parameter]
        public Guid? Id { get; set; }

        [Parameter]
        public bool IsReadOnly { get; set; }

        private CreateUpdateContractorProfileDto Profile { get; set; } = new CreateUpdateContractorProfileDto();

        private Validations Validator;

        private bool SpecializationsInvalid { get; set; }
        private bool ValidatorIsInvalid { get; set; }

        private string selectedTab = "General";

        protected override async Task OnParametersSetAsync()
        {
            if (Id.HasValue)
            {
                var profile = await contractorAppService.GetAsync(Id.Value);
                Profile = ObjectMapper.Map<ContractorProfileDto, CreateUpdateContractorProfileDto>(profile);


                SelectedSpecializations = Enum.GetValues(typeof(ProjectTaskType))
                    .Cast<ProjectTaskType>()
                    .Where(task => Profile.Specializations.HasFlag(task))
                    .ToList();
            }
            else
            {
                Profile = new CreateUpdateContractorProfileDto();
            }

            await base.OnParametersSetAsync();
        }

        private async Task Save()
        {
            var isValid = await Validator.ValidateAll();
            ValidatorIsInvalid = !isValid;
            if (isValid)
            {
                foreach (var item in Profile.PortfolioItems.Where(x => x.IsDeleted))
                {
                    // removed portfolio item, cleanup blob storage
                    await contractorAppService.DeletePortfolioItemAsync(item.BlobName);
                }

                Profile.PortfolioItems = Profile.PortfolioItems.Where(x => !x.IsDeleted).ToList();

                if (SelectedSpecializations.Count == 0)
                {
                    SpecializationsInvalid = true;
                    return;
                }

                ProjectTaskType selectedSpecializations = SelectedSpecializations.First();

                foreach (var task in SelectedSpecializations.Skip(1))
                {
                    selectedSpecializations |= task;  // Bitwise OR
                }

                Profile.Specializations = selectedSpecializations;

                if (!Id.HasValue)
                {
                    await contractorAppService.CreateAsync(Profile);
                }
                else
                {
                    await contractorAppService.UpdateAsync(Id.Value, Profile);
                }
                Nav.NavigateTo("/ContractorDashboard", true);
            }
        }

        private async Task Cancel()
        {
            foreach (var item in Profile.PortfolioItems.Where(x => !x.Id.HasValue))
            {
                // new unsaved portfolio item, cleanup blob storage
                await contractorAppService.DeletePortfolioItemAsync(item.BlobName);
            }

            Nav.NavigateTo("/ContractorDashboard", true);
        }

        private async Task OnSelectedTabChanged(string name)
        {
            selectedTab = name;

            await Task.CompletedTask;
        }

        private bool IsTaskSelected(ProjectTaskType task)
        {
            return SelectedSpecializations.Contains(task);
        }

        private void ToggleSelection(ProjectTaskType task)
        {
            if (SelectedSpecializations.Contains(task))
            {
                SelectedSpecializations.Remove(task);
            }
            else
            {
                SelectedSpecializations.Add(task);
            }
        }

        private List<ProjectTaskType> SelectedSpecializations = new List<ProjectTaskType>();
    }
}
