﻿using BuilderPulsePro.Maui.Pages;
using BuilderPulsePro.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace BuilderPulsePro.Maui;

public partial class AppShell : Shell, ITransientDependency
{
    public AppShell(ShellViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();

        Routing.RegisterRoute(nameof(IdentityUserCreateModalPage), typeof(IdentityUserCreateModalPage));
        Routing.RegisterRoute(nameof(IdentityUserEditModalPage), typeof(IdentityUserEditModalPage));
        Routing.RegisterRoute(nameof(ProfilePicturePage), typeof(ProfilePicturePage));
        Routing.RegisterRoute(nameof(ChangePasswordPage), typeof(ChangePasswordPage));
        Routing.RegisterRoute(nameof(LoginOrLogoutPage), typeof(LoginOrLogoutPage));
    }
}
