using BuilderPulsePro.Builders;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BuilderPulsePro.Blazor.Pages
{
    public partial class BuilderProfilePage
    {
        [Parameter]
        public Guid? Id { get; set; }
    }
}
