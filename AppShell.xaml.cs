using Punjab_Ornaments.Presentation.Views;

namespace Sonaar;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		RegisterRoutes();
    }

    private void RegisterRoutes()
	{
        //Auth
        Routing.RegisterRoute(nameof(UnderConstruction), typeof(UnderConstruction));
    }
}