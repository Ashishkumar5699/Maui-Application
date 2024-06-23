using Sonaar.Mobile.UI.Authentication;

namespace Sonaar.Mobile.UI.Registry.UIRegistry
{
    public static class ViewRegistry
	{
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<AuthPage>();

            return mauiAppBuilder;
        }

    }
}

