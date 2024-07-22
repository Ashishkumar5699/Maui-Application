using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Punjab_Ornaments.Infrastructure.ServiceHelper;
using Punjab_Ornaments.Presentation.Views;
using Sonaar.Infrastructure.AlertService;
using Sonaar.Infrastructure.APIService;
using Sonaar.Infrastructure.Database;
using Sonaar.Infrastructure.Navigation;
using Sonaar.Localization.Database;
using Sonaar.Presentation.Viewmodels.Auth;

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
		return app;
	}
	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
		//Auth
        mauiAppBuilder.Services.AddSingleton<LoginPageViewModel>();
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
		return mauiAppBuilder;
	}
	public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{

		//Auth
        mauiAppBuilder.Services.AddSingleton<LoginPageView>();


        return mauiAppBuilder;
	}
}

