using System;
using Sonaar.Mobile.UI.Authentication;

namespace Sonaar.Mobile.UI.Registry.UIRegistry
{
	public static class ViewModelRegistry
	{
        public static MauiAppBuilder RegisterVieModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<AuthPageViewModel>();
            return mauiAppBuilder;
        }
    }
}

