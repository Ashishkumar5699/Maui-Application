using Sonaar.Mobile.UI;

namespace Sonaar.Mobile.UI.Registry.UIRegistry
{
    public static class ViewRegistry
	{
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<Authentication.AuthPage>();

            mauiAppBuilder.Services.AddSingleton<Mortgage.MortgagePage>();

            mauiAppBuilder.Services.AddSingleton<QuickSale.SalePageView>();


            mauiAppBuilder.Services.AddSingleton<Customer.CustomerListPage>();

            return mauiAppBuilder;
        }

    }
}

