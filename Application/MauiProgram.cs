using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Sonaar.Infrastructure.AlertService;
using Sonaar.Infrastructure.APIService;
using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;
using Sonaar.Localization.Database;
using Sonaar.Presentation.Viewmodels;
using Sonaar.Presentation.Viewmodels.Approval;
using Sonaar.Presentation.Viewmodels.Common;
using Sonaar.Presentation.Viewmodels.HomePage.Customer;
using Sonaar.Presentation.Viewmodels.HomePage.Purchase;
using Sonaar.Presentation.Viewmodels.QuickSale;
using Sonaar.Presentation.Viewmodels.Settings;
using Sonaar.Presentation.Views;
using Sonaar.Presentation.Views.Approval;
using Sonaar.Presentation.Views.Customer;
using Sonaar.Presentation.Views.Purchase;
using Sonaar.Presentation.Views.QuickSale;
using Sonaar.Presentation.Views.Settings;

namespace Sonaar;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.RegisterAppServices();
		builder.RegisterViewModels();
		builder.RegisterViews();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		//return builder.Build();
		var app = builder.Build();
        ServiceHelper.Initialize(app.Services);
        Sonaar.Mobile.UI.Common.ServiceHelper.Initialize(app.Services);
		return app;
	}
	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
		//Auth
        //mauiAppBuilder.Services.AddSingleton<LoginPageViewModel>();

		//Home Page
        mauiAppBuilder.Services.AddSingleton<HomePageViewModel>();
        mauiAppBuilder.Services.AddSingleton<StockViewModel>();
        mauiAppBuilder.Services.AddSingleton<GoldStockListViewModel>();
        mauiAppBuilder.Services.AddSingleton<GoldStockDetailPageViewModel>();
        mauiAppBuilder.Services.AddSingleton<AddNewCustomerPageViewModel>();
        mauiAppBuilder.Services.AddSingleton<PendingApprovalsViewModel>();
        mauiAppBuilder.Services.AddSingleton<CustomerListViewModel>();

        //Approval Page
        mauiAppBuilder.Services.AddSingleton<AddPurchaseViewModel>();
        mauiAppBuilder.Services.AddSingleton<PendingApprovalsViewModel>();
        mauiAppBuilder.Services.AddSingleton<CompleteApprovalViewModel>();
        mauiAppBuilder.Services.AddSingleton<PurchaseDetailViewModel>();

		//Settings
        mauiAppBuilder.Services.AddSingleton<SettingPageViewModel>();
        mauiAppBuilder.Services.AddSingleton<MetalTypePageViewModel>();
        mauiAppBuilder.Services.AddSingleton<MetalTypeDetailPageViewModel>();

		//Quick Sale
        mauiAppBuilder.Services.AddSingleton<SalePageViewModel>();

        Sonaar.Mobile.UI.Registry.UIRegistry.ViewModelRegistry.RegisterVieModels(mauiAppBuilder);

        return mauiAppBuilder;
	}

	public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
		//mauiAppBuilder.Services.AddSingleton<IDataService, SQLiteDataService>();
		mauiAppBuilder.Services.AddSingleton<IDataService, RESTDataService>();
		mauiAppBuilder.Services.AddSingleton<IAPIService, APIService>();
		//mauiAppBuilder.Services.AddSingleton<IRestService, RestService>();
		mauiAppBuilder.Services.AddSingleton<IAlertService, AlertService>();

        Sonaar.Mobile.UI.Registry.ServiceRegistry.AppServiceRegistry.RegisterViews(mauiAppBuilder);

		return mauiAppBuilder;
	}

	public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{

		//Auth
        //mauiAppBuilder.Services.AddSingleton<LoginPage>();

		//Home Page
        mauiAppBuilder.Services.AddSingleton<HomePageView>();
        mauiAppBuilder.Services.AddSingleton<StockView>();
        mauiAppBuilder.Services.AddSingleton<GoldStockList>();
        mauiAppBuilder.Services.AddSingleton<AddGoldStock>();
        mauiAppBuilder.Services.AddSingleton<GoldStockDetailPage>();
        mauiAppBuilder.Services.AddSingleton<AddNewCustomerPage>();
        mauiAppBuilder.Services.AddSingleton<CustomerListPage>();
        mauiAppBuilder.Services.AddSingleton<AddPurchase>();

		//Approval Page
        mauiAppBuilder.Services.AddSingleton<PendingApprovalsView>();
        mauiAppBuilder.Services.AddSingleton<CompleteApprovalsView>();
        mauiAppBuilder.Services.AddSingleton<PurchaseDetailPage>();

		//Setting
        mauiAppBuilder.Services.AddSingleton<SettingPage>();
        mauiAppBuilder.Services.AddSingleton<MetalTypePage>();
        mauiAppBuilder.Services.AddSingleton<MetalTypeDetailPage>();

		//Quick Sale
        mauiAppBuilder.Services.AddSingleton<SalePageView>();

        Sonaar.Mobile.UI.Registry.UIRegistry.ViewRegistry.RegisterViews(mauiAppBuilder);

        return mauiAppBuilder;
	}
}

