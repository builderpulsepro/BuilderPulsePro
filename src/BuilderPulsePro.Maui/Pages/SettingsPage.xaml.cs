using BuilderPulsePro.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace BuilderPulsePro.Maui.Pages;

public partial class SettingsPage : ContentPage, ITransientDependency
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}