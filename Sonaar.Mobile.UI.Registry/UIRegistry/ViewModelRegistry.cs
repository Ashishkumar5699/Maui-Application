using System;
using Sonaar.Mobile.UI;

namespace Sonaar.Mobile.UI.Registry.UIRegistry
{
	public static class ViewModelRegistry
	{
        public static MauiAppBuilder RegisterVieModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<Authentication.AuthPageViewModel>();
            mauiAppBuilder.Services.AddSingleton<Mortgage.MortgageViewModel>();
            mauiAppBuilder.Services.AddSingleton<QuickSale.SalePageViewModel>();

            return mauiAppBuilder;
        }
    }
}

