using BuilderPulsePro.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace BuilderPulsePro.Maui.Pages;

public partial class IdentityUserCreateModalPage : ContentPage, ITransientDependency
{
    public IdentityUserCreateModalPage(IdentityUserCreateViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}