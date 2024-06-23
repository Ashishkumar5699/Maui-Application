using Sonaar.Mobile.UI.Authentication;

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
    }
}
