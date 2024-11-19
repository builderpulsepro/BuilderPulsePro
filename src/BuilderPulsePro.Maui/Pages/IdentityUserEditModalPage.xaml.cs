using BuilderPulsePro.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace BuilderPulsePro.Maui.Pages;

public partial class IdentityUserEditModalPage : ContentPage, ITransientDependency
{
	public IdentityUserEditModalPage(IdentityUserEditViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}