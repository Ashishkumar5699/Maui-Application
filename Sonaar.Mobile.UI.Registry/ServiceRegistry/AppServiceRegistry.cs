using Sonaar.Mobile.RestBridge.RestService;
using Sonaar.Mobile.Services.AlertService;
using Sonaar.Mobile.Services.AuthService;
using Sonaar.Mobile.Services.CustomerService;
using Sonaar.Mobile.Services.Navigation;
using Sonaar.Mobile.Services.PopupService;
using Sonaar.Mobile.Services.PrintService;
using Sonaar.Services.BusinessLayer.Auth;
using Sonaar.Services.BusinessLayer.Consumer;
using Sonaar.Services.BusinessLayer.Print;

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

            mauiAppBuilder.Services.AddSingleton<IPrintService, PrintService>();
            mauiAppBuilder.Services.AddSingleton<IPrintProvider, PrintProvider>();

            mauiAppBuilder.Services.AddSingleton<IPrintProvider, PrintProvider>();

            mauiAppBuilder.Services.AddSingleton<ISalePopupService, SalePopupService>();

            mauiAppBuilder.Services.AddSingleton<ICustomerService, CustomerService>();
            mauiAppBuilder.Services.AddSingleton<IConsumerProvider, ConsumerProvider>();

            return mauiAppBuilder;
        }
    }
}

