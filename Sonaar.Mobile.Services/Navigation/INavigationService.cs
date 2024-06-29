using System;
namespace Sonaar.Mobile.Services.Navigation
{
	public interface INavigationService
	{
        Task NavigateToAsync(NavigationPath route, string routeParameters = null, object routeobj = null);

        Task PopAsync();
    }
}

