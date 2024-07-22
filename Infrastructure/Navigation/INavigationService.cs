using Sonaar.Resources.Constant;

namespace Sonaar.Infrastructure.Navigation
{
    public interface INavigationService
    {
        //Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);
        Task NavigateToAsync(NavigationPath route, string routeParameters = null, object routeobj = null);


        Task PopAsync();
    }
}
