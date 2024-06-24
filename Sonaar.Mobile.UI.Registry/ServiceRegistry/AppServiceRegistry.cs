using System;
using Sonaar.Mobile.RestBridge.RestService;
using Sonaar.Mobile.Services.AlertService;
using Sonaar.Mobile.Services.AuthService;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Services.BusinessLayer.Auth;

namespace Sonaar.Mobile.UI.Registry.ServiceRegistry
{
	public static class AppServiceRegistry
	{
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
            mauiAppBuilder.Services.AddSingleton<IAuthService, AuthService>();
            mauiAppBuilder.Services.AddSingleton<IAuthProvider, AuthProvider>();
            mauiAppBuilder.Services.AddSingleton<IRestService, RestService>();
            mauiAppBuilder.Services.AddSingleton<IAlertService, AlertService>();

            return mauiAppBuilder;
        }
    }
}

