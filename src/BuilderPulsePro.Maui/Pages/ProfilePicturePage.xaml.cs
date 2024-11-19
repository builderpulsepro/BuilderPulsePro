using BuilderPulsePro.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace BuilderPulsePro.Maui.Pages;

public partial class ProfilePicturePage : ContentPage, ITransientDependency
{
    public ProfilePicturePage(ProfilePictureViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}