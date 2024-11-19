using BuilderPulsePro.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace BuilderPulsePro.Maui.Pages;

public partial class LoginOrLogoutPage : ContentPage, ITransientDependency
{
	public LoginOrLogoutPage(LoginOrLogoutViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}