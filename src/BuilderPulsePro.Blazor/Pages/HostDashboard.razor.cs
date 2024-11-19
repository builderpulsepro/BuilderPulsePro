using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.BlazoriseUI;
using Volo.Abp.Timing;

namespace BuilderPulsePro.Blazor.Pages;

public partial class HostDashboard
{
    [Inject]
    public IPermissionChecker PermissionChecker { get; set; } = default!;

    protected List<BreadcrumbItem> BreadcrumbItems = new();

    protected DateTime StartDate { get; set; }

    protected DateTime EndDate { get; set; }

    protected async override Task OnInitializedAsync()
    {
        StartDate = Clock.Now.AddMonths(-1).Date;
        EndDate = Clock.Now.Date;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await SetBreadcrumbItemsAsync();
            await InvokeAsync(StateHasChanged);
        }
    } 

    protected virtual async Task RefreshAsync()
    {
    }

    protected virtual ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.Add(new BreadcrumbItem(L["Dashboard"]));
        return ValueTask.CompletedTask;
    }

    protected virtual Task OnDatesChangedAsync(IReadOnlyList<DateTime> dates)
    {
        StartDate = dates.Min();
        EndDate = dates.Max();

        return Task.CompletedTask;
    }
}
