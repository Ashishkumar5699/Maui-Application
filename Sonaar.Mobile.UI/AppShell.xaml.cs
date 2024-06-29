using Sonaar.Mobile.UI.Authentication;
using Sonaar.Mobile.UI.Mortgage;

namespace Sonaar.Mobile.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        AppShell.RegisterRoutes();
    }
    private static void RegisterRoutes()
    {
        //Auth
        Routing.RegisterRoute(nameof(AuthPage), typeof(AuthPage));

        Routing.RegisterRoute(nameof(MortgagePage), typeof(MortgagePage));
    }
}
