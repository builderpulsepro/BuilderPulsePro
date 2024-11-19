using CommunityToolkit.Mvvm.Input;
using Volo.Abp.DependencyInjection;

namespace BuilderPulsePro.Maui.ViewModels;

public partial class MainPageViewModel : BuilderPulseProViewModelBase, ITransientDependency
{
    public MainPageViewModel()
    {
    }

    [RelayCommand]
    async Task SeeAllUsers()
    {
        await Shell.Current.GoToAsync("///users");
    }
}
