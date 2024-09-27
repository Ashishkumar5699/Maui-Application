namespace Sonaar.Mobile.UI.Registry.UIRegistry
{
    public static class ViewModelRegistry
	{
        public static MauiAppBuilder RegisterVieModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<Authentication.AuthPageViewModel>();

            mauiAppBuilder.Services.AddSingleton<Mortgage.MortgageViewModel>();

            mauiAppBuilder.Services.AddSingleton<QuickSale.SalePageViewModel>();

            mauiAppBuilder.Services.AddSingleton<Customer.CustomerListPageViewModel>();

            mauiAppBuilder.Services.AddSingleton<Customer.AddNewCustomerPageViewModel>();

            return mauiAppBuilder;
        }
    }
}

