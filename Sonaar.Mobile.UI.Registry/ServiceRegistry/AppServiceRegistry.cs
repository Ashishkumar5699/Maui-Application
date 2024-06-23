using System;
using Sonaar.Mobile.Services.Navigation;

namespace Sonaar.Mobile.UI.Registry.ServiceRegistry
{
	public static class AppServiceRegistry
	{
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();

            return mauiAppBuilder;
        }
    }
}

