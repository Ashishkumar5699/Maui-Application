using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Punjab_Ornaments.Infrastructure.AlertService;
using Punjab_Ornaments.Infrastructure.APIService;
using Punjab_Ornaments.Infrastructure.Database;
using Punjab_Ornaments.Infrastructure.Navigation;
using Punjab_Ornaments.Infrastructure.RestService;
using Punjab_Ornaments.Localization.Database;
using Punjab_Ornaments.Presentation.Viewmodels;
using Punjab_Ornaments.Presentation.Viewmodels.Approval;
using Punjab_Ornaments.Presentation.Viewmodels.Auth;
using Punjab_Ornaments.Presentation.Viewmodels.Common;
using Punjab_Ornaments.Presentation.Viewmodels.HomePage.Customer;
using Punjab_Ornaments.Presentation.Viewmodels.HomePage.Purchase;
using Punjab_Ornaments.Presentation.Viewmodels.Settings;
using Punjab_Ornaments.Presentation.Views;
using Punjab_Ornaments.Presentation.Views.Approval;
using Punjab_Ornaments.Presentation.Views.Auth;
using Punjab_Ornaments.Presentation.Views.Customer;
using Punjab_Ornaments.Presentation.Views.Purchase;
using Punjab_Ornaments.Presentation.Views.Settings;

namespace Punjab_Ornaments;

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
		return app;
	}
	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
		//Auth
        mauiAppBuilder.Services.AddSingleton<LoginPageViewModel>();

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


        return mauiAppBuilder;
	}

	public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
		//mauiAppBuilder.Services.AddSingleton<IDataService, SQLiteDataService>();
		mauiAppBuilder.Services.AddSingleton<IDataService, RESTDataService>();
		mauiAppBuilder.Services.AddSingleton<IAPIService, APIService>();
		mauiAppBuilder.Services.AddSingleton<IRestService, RestService>();
		mauiAppBuilder.Services.AddSingleton<IAlertService, AlertService>();
		return mauiAppBuilder;
	}
	public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{

		//Auth
        mauiAppBuilder.Services.AddSingleton<LoginPage>();

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


        return mauiAppBuilder;
	}
}

