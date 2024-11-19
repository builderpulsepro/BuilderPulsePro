using BuilderPulsePro.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace BuilderPulsePro.Maui;

public partial class MainPage : ContentPage, ITransientDependency
{
    public MainPage(
		MainPageViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
    }
}