using System;
using CommunityToolkit.Maui;

namespace Sonaar.Mobile.UI.Registry.PackageRegistry
{
	public static class MauiPackageRegistry
	{
        public static MauiAppBuilder RegisterMauiPackage(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.UseMauiCommunityToolkit();
            return mauiAppBuilder;
        }

    }
}

